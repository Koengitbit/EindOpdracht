using EindOpdracht.Data;
using EindOpdracht.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EindOpdracht.Controllers
{
    [ApiVersion("1.0")]
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
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Locations>>> GetLocation()
        {
            return await _context.Locations.ToListAsync();
        }
    }
}
