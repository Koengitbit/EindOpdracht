using Asp.Versioning;
using AutoMapper;
using EindOpdracht.Data;
using EindOpdracht.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EindOpdracht.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly EindOpdrachtDbContext _context;
        public ImageController(EindOpdrachtDbContext context)
        {
            _context = context;
        }
        // GET: api/Images
        [HttpGet]
        [Route("")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Image>>> GetImage()
        {
            return await _context.Images.ToListAsync();
        }
    }
}
