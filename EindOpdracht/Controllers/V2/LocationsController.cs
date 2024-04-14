﻿using Asp.Versioning;
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
        [HttpGet]
        [Route("")]
        [Route("GetNew")]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocation()
        {
            var locations = await _context.Locations
                                  .Include(l => l.Images) // Make sure to include the Images
                                  .Include(lan => lan.Landlord)
                                  .ToListAsync();
            var locationDTOs = _mapper.Map<LocationV2DTO[]>(locations);
            return Ok(locationDTOs);
        }
    }
}
