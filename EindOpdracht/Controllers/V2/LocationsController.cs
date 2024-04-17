using Asp.Versioning;
using AutoMapper;
using EindOpdracht.Data;
using EindOpdracht.DTO;
using EindOpdracht.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EindOpdracht.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : Controller
    {
        private readonly EindOpdrachtDbContext _context;
        private readonly IMapper _mapper;
        public LocationsController(EindOpdrachtDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        // GET: api/Locations
        /// <summary>
        /// Gets all locations for version 2 with images and landlords.
        /// </summary>
        [HttpGet]
        [Route("")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocation(CancellationToken cancellationToken)
        {
            var locations = await _context.Locations
                                  .Include(l => l.Images)
                                  .Include(lan => lan.Landlord)
                                  .ToListAsync(cancellationToken);
            var locationDTOs = _mapper.Map<LocationDTOV2[]>(locations);
            return Ok(locationDTOs);
        }
    }
}
