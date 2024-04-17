using Asp.Versioning;
using AutoMapper;
using EindOpdracht.Data;
using Microsoft.AspNetCore.Mvc;

namespace EindOpdracht.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly EindOpdrachtDbContext _context;
        private readonly IMapper _mapper;
        public ReservationsController(EindOpdrachtDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
