using EindOpdracht.Data;
using EindOpdracht.Models;
using EindOpdracht.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EindOpdracht.Repository
{
    public class EindOpdrachtRepository
    {
        private readonly EindOpdrachtDbContext _context;

        public EindOpdrachtRepository(EindOpdrachtDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            _context = context;
        }

        public async Task<List<Location>> GetAllLocationsAsync(CancellationToken cancellationToken)
        {
            return await _context.Locations
                .Include(l => l.Images)
                .Include(l => l.Landlord)
                .ToListAsync(cancellationToken);
        }

        public async Task<float> GetMaxPriceAsync(CancellationToken cancellationToken)
        {
            return await _context.Locations.MaxAsync(l => l.PricePerDay, cancellationToken);
        }

        public async Task<List<Location>> SearchLocationsAsync(
            Func<IQueryable<Location>, IQueryable<Location>> queryModifier, CancellationToken cancellationToken)
        {
            var query = _context.Locations.AsQueryable();
            query = queryModifier(query);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Location> GetLocationByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Locations
                .Include(l => l.Images)
                .Include(l => l.Landlord)
                .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
        }

        public async Task<List<DateTime>> GetUnAvailableDatesAsync(int locationId, CancellationToken cancellationToken)
        {
            var reservations = await _context.Reservations
                .Where(r => r.LocationId == locationId && r.EndDate >= DateTime.Today)
                .ToListAsync(cancellationToken);

            var unavailableDates = new List<DateTime>();
            foreach (var reservation in reservations)
            {
                for (DateTime date = reservation.StartDate.Date; date <= reservation.EndDate.Date; date = date.AddDays(1))
                {
                    unavailableDates.Add(date);
                }
            }

            return unavailableDates;
        }

        //Reservations
        public async Task<Customer> FindOrCreateCustomerAsync(string email, string firstName, string lastName, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
            if (customer == null)
            {
                customer = new Customer { Email = email, FirstName = firstName, LastName = lastName };
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return customer;
        }

        public async Task<Reservation> CreateReservationAsync(Reservation reservation, CancellationToken cancellationToken)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync(cancellationToken);
            return reservation;
        }

        public async Task<(string LocationName, float PricePerDay)> GetLocationDetailsAsync(int locationId, CancellationToken cancellationToken)
        {
            var location = await _context.Locations.Where(l => l.Id == locationId)
                .Select(l => new { l.Title, l.PricePerDay }).FirstOrDefaultAsync(cancellationToken);
            return (location.Title, location.PricePerDay);
        }
    }
}
