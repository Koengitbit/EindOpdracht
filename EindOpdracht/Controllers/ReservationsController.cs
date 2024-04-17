using Asp.Versioning;
using AutoMapper;
using EindOpdracht.Data;
using EindOpdracht.DTO.Exchange;
using EindOpdracht.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        /// <summary>
        /// Make customer if customer doesn't exist and make a reservation,
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ReservationResponseDto>> CreateReservation(ReservationRequestDTO requestDto, CancellationToken cancellationToken)
        {
            // Check if the customer exists
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == requestDto.Email, cancellationToken);

            // If customer doesn't exist, create a new one
            if (customer == null)
            {
                customer = new Customer
                {
                    Email = requestDto.Email,
                    FirstName = requestDto.FirstName,
                    LastName = requestDto.LastName
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync(cancellationToken);
            }

            // Create the reservation
            var reservation = new Reservation
            {
                StartDate = requestDto.StartDate,
                EndDate = requestDto.EndDate,
                LocationId = requestDto.LocationId,
                CustomerId = customer.Id,
                Discount = requestDto.Discount ?? 0
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync(cancellationToken);

            // Retrieve location name
            var locationName = await _context.Locations
                .Where(l => l.Id == requestDto.LocationId)
                .Select(l => l.Title)
                .FirstOrDefaultAsync(cancellationToken);

            var locationPrice = await _context.Locations
                .Where(l => l.Id == requestDto.LocationId)
                .Select(l => l.PricePerDay)
                .FirstOrDefaultAsync(cancellationToken);

            int numberOfDays = (int)(requestDto.EndDate - requestDto.StartDate).TotalDays;
            float price = numberOfDays * locationPrice;
            float totalPrice = price - (price * requestDto.Discount ?? 0);
            
            //Res
            var responseDto = new ReservationResponseDto
            {
                LocationName = locationName,
                CustomerName = $"{customer.FirstName} {customer.LastName}",
                Price = totalPrice,
                Discount = requestDto.Discount ?? 0
            };
            return Ok(responseDto);
        }
    }
}

