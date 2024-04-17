using Asp.Versioning;
using AutoMapper;
using EindOpdracht.Data;
using EindOpdracht.DTO;
using EindOpdracht.Models;
using EindOpdracht.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace EindOpdracht.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly SearchService _searchService;

        public LocationsController(SearchService searchService)
        {
            ArgumentNullException.ThrowIfNull(searchService);
            _searchService = searchService;
        }
        // GET: api/Locations
        /// <summary>
        /// Gets all locations with images and landlords.
        /// </summary>
        [HttpGet]
        [Route("")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocation(CancellationToken cancellationToken)
        {
            var locationDTOs = await _searchService.GetLocationsAsync(cancellationToken);
            return Ok(locationDTOs);
        }
        /// <summary>
        /// Gets the max price of all locations.
        /// </summary>
        [HttpGet]
        [Route("GetMaxPrice")]
        public async Task<ActionResult<int>> GetMaxPrice(CancellationToken cancellationToken)
        {
            var maxPrice = await _searchService.GetMaxPriceAsync(cancellationToken);
            return Ok(new { Price = maxPrice });
        }
        /// <summary>
        /// Returns DTO based on Search results
        /// </summary>
        [HttpPost]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<Location>>> Search([FromBody] SearchDTO searchDto, CancellationToken cancellationToken)
        {
            var locationDTOs = await _searchService.SearchLocationsAsync(searchDto, cancellationToken);
            return Ok(locationDTOs);
        }

        /// <summary>
        /// Gets details of a location by Id.
        /// </summary>
        [HttpGet]
        [Route("GetDetails/{id}")]
        public async Task<ActionResult<IEnumerable<Location>>> GetDetails(int id, CancellationToken cancellationToken)
        {
            var locationDetailsDTO = await _searchService.GetLocationDetailsAsync(id, cancellationToken);
            if (locationDetailsDTO == null)
                return NotFound();

            return Ok(locationDetailsDTO);
        }

        /// <summary>
        /// Shows UnAvailableDates Per LocationId
        /// </summary>
        [HttpGet]
        [Route("UnAvailableDates/{locationId}")]
        public async Task<ActionResult<UnAvailableDatesResponseDTO>> UnAvailableDates(int locationId, CancellationToken cancellationToken)
        {
            var responseDTO = await _searchService.GetUnAvailableDatesAsync(locationId, cancellationToken);
            if (responseDTO == null)
                return NotFound();

            return Ok(responseDTO);
        }
    }
}
