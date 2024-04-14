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
    }
}
