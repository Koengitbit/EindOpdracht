using Asp.Versioning;
using AutoMapper;
using EindOpdracht.Data;
using EindOpdracht.DTO.Exchange;
using EindOpdracht.Models;
using EindOpdracht.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EindOpdracht.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationService _reservationService;
        public ReservationsController(ReservationService reservationService)
        {
            ArgumentNullException.ThrowIfNull(reservationService);
            _reservationService = reservationService;
        }
        /// <summary>
        /// Make customer if customer doesn't exist and make a reservation,
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ReservationResponseDto>> CreateReservation(ReservationRequestDTO requestDto, CancellationToken cancellationToken)
        {
            var responseDto = await _reservationService.CreateReservationAsync(requestDto, cancellationToken);
            return Ok(responseDto);
        }
    }
}

