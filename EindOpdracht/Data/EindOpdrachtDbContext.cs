using EindOpdracht.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EindOpdracht.Data
{
    public class EindOpdrachtDbContext : DbContext
    {
        public EindOpdrachtDbContext(DbContextOptions<EindOpdrachtDbContext> options) : base(options)
        {

        }
        //DbSets under here
        public DbSet<Location> Locations { get; set; }


        //Seeding data here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model builder.entity etc hier
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Title = "De Boerenhoeve",
                    SubTitle = "Lekker veel ruimte",
                    Description = "Description",
                    Rooms = 5,
                    NumberOfGuests = 5,
                    PricePerDay = 5,
                    Features = Features.Smoking, // Can hold multiple enums potentially (?)
                    LocationType = LocationType.Hotel // Single enum
                }
                );
        }
    }
}
