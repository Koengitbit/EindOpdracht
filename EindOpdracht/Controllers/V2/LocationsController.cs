using Asp.Versioning;
using EindOpdracht.Data;
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
        public LocationsController(EindOpdrachtDbContext context)
        {
            _context = context;
        }
        // GET: api/Locations
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocation()
        {
            return await _context.Locations.ToListAsync();
        }
    }
}
