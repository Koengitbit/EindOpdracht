using Asp.Versioning;
using AutoMapper;
using EindOpdracht.Data;
using EindOpdracht.DTO;
using EindOpdracht.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EindOpdracht.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly EindOpdrachtDbContext _context;
        private readonly IMapper _mapper;
        public LocationsController(EindOpdrachtDbContext context, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(mapper);
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Locations
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocation()
        {
            var locations = await _context.Locations
                .Include(l => l.Images)
                .Include(Land => Land.Landlord)
                .ToListAsync();
            var locationDTOs = _mapper.Map<LocationDTO[]>(locations);
            return Ok(locationDTOs);
        }
        [HttpGet]
        [Route("GetMaxPrice")]
        public async Task<ActionResult<int>> GetMaxPrice(CancellationToken cancellationToken)
        {
            var maxPrice = await _context.Locations.MaxAsync(l => l.PricePerDay, cancellationToken);
            return Ok(new { Price = maxPrice });
        }
        [HttpGet]
        [Route("GetMaxRooms")]
        public async Task<ActionResult<int>> GetMaxRooms(CancellationToken cancellationToken)
        {
            var maxRooms = await _context.Locations.MaxAsync(l => l.Rooms, cancellationToken);
            return Ok(new { Rooms = maxRooms });
        }
        [HttpPost]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<Location>>> Search([FromBody] SearchDTO searchDto, CancellationToken cancellationToken)
        {
            var query = _context.Locations.AsQueryable();
            query = query.Include(l => l.Images)
                .Include(l => l.Landlord);

            if (searchDto.Features.HasValue)
            {
                query = query.Where(l => (l.Features & (Features)searchDto.Features.Value) == (Features)searchDto.Features.Value);
            }
            if (searchDto.Type.HasValue)
                query = query.Where(l => l.LocationType == (LocationType)searchDto.Type.Value);
            if (searchDto.Rooms.HasValue)
                query = query.Where(l => l.Rooms >= searchDto.Rooms.Value);
            if (searchDto.MinPrice.HasValue)
                query = query.Where(l => l.PricePerDay >= searchDto.MinPrice.Value);
            if (searchDto.MaxPrice.HasValue)
                query = query.Where(l => l.PricePerDay <= searchDto.MaxPrice.Value);

            var locations = await query.ToListAsync(cancellationToken);
            var locationDTOs = _mapper.Map<LocationDTOV2[]>(locations);
            return Ok(locationDTOs);
        }

        [HttpGet]
        [Route("GetDetails/{id}")]
        public async Task<ActionResult<IEnumerable<Location>>> GetDetails(int id, CancellationToken cancellationToken)
        {
            var location = await _context.Locations
                .Include(l => l.Images)
                .Include(l => l.Landlord)
                .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

            if (location == null)
            {
                return NotFound();
            }
            var locationDetailsDTO = _mapper.Map<LocationDetailsDTO>(location);
            return Ok(locationDetailsDTO);
        }


/*        [HttpGet]
        [Route("UnAvailableDates/{id}")]
        public async Task<ActionResult<IEnumerable<Location>>> UnAvailableDates(int id, CancellationToken cancellationToken)
        {
        }*/
    }
}
