using Asp.Versioning;
using AutoMapper;
using EindOpdracht.Data;
using EindOpdracht.DTO;
using EindOpdracht.Models;
using EindOpdracht.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EindOpdracht.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : Controller
    {
        private readonly SearchService _searchService;
        public LocationsController(SearchService searchService)
        {
            ArgumentNullException.ThrowIfNull(searchService);
            _searchService = searchService;
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
            var locationDTOs = await _searchService.GetLocationsV2Async(cancellationToken);
            return Ok(locationDTOs);
        }
    }
}
