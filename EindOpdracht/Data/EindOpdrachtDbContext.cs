using EindOpdracht.Models;
using Microsoft.EntityFrameworkCore;

namespace EindOpdracht.Data
{
    public class EindOpdrachtDbContext : DbContext
    {
        public EindOpdrachtDbContext(DbContextOptions<EindOpdrachtDbContext> options) : base(options)
        {

        }
        //DbSets under here
        public DbSet<Locations> Locations { get; set; }

        //Seeding data here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model builder.entity etc hier
            modelBuilder.Entity<Locations>().HasData(
                new Locations
                {
                    Id = 1,
                    Title = "De Boerenhoeve",
                    SubTitle = "Lekker veel ruimte",
                    Description = "Description",
                    Rooms = 5,
                    NumberOfGuests = 5,
                    PricePerDay = 5,
                    Features = (Features.Smoking | Features.PetsAllowed | Features.Wifi), // multiple enum flags
                    LocationType = LocationType.Hotel // Single enum
                }
                );
        }
    }
}
