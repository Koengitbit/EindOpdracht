using EindOpdracht.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace EindOpdracht.Data
{
    public class EindOpdrachtDbContext : DbContext
    {
        public EindOpdrachtDbContext(DbContextOptions<EindOpdrachtDbContext> options) : base(options)
        {

        }
        //DbSets under here
        public DbSet<Location> Locations { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        
        //Seeding data here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasMany(e => e.Images)
                .WithOne(e => e.Location)
                .HasForeignKey(e => e.LocationId)
                .IsRequired(false);

            modelBuilder.Entity<Landlord>()
                .HasMany(e => e.Locations)
                .WithOne(e => e.Landlord)
                .HasForeignKey(e => e.LandlordId)
                .IsRequired(false);

            // Model builder.entity etc hier
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Title = "De Boerenhoeve",
                    SubTitle = "Lekker veel ruimte",
                    Description = "De camping ligt verscholen achter de boerderij in de polder. Op fietsafstand (5 minuten) liggen het dorpje Nieuwvliet, de zee, het strand, het bos van Erasmus en het natuurgebied de Knokkert.",
                    Rooms = 5,
                    NumberOfGuests = 5,
                    PricePerDay = 500,
                    Features = Features.Smoking, // Can hold multiple enums potentially (?)
                    LocationType = LocationType.Cottage, // Single enum
                    LandlordId = 1
                },
                new Location
                {
                    Id = 2,
                    Title = "Frankie's Penthouse",
                    SubTitle = "Te gek uitzicht",
                    Description = "Nee, dit puike penthouse dat al jaren te koop stond en nu is verkocht, is niet de duurste woning van ons land. Bij lange na niet. Wel is de meer dan €30.000 per vierkante meter woonruimte een record in ons land.",
                    Rooms = 5,
                    NumberOfGuests = 5,
                    PricePerDay = 2000,
                    Features = Features.Smoking,
                    LocationType = LocationType.House,
                    LandlordId = 2
                },
                new Location
                {
                    Id = 3,
                    Title = "Trump's Wall",
                    SubTitle = "The Great American Wall",
                    Description = "This powerful barrier is a vital step in securing our nation’s borders. By stopping illegal immigration, drugs, and crime, we are protecting the American people and upholding our laws. The Great American Wall stands as a symbol of strength, sovereignty, and the unwavering resolve of the United States to maintain its integrity and safety.",
                    Rooms = 5,
                    NumberOfGuests = 5,
                    PricePerDay = 5,
                    Features = Features.Smoking,
                    LocationType = LocationType.Room,
                    LandlordId = 3
                },
                new Location
                {
                    Id = 4,
                    Title = "Marina Bay Sands",
                    SubTitle = "Luxury Hotel and Entertainment Complex",
                    Description = "Marina Bay Sands is an iconic luxury hotel and entertainment complex in Singapore, renowned for its distinctive architecture featuring three interconnected towers and a SkyPark. The complex includes a range of amenities such as the world's largest rooftop infinity pool, a museum, high-end shopping, dining options, a casino, and an observation deck with panoramic views of the city.",
                    Rooms = 2500,
                    NumberOfGuests = 5,
                    PricePerDay = 300,
                    Features = Features.Smoking,
                    LocationType = LocationType.Hotel,
                    LandlordId = 3
                },
                new Location
                {
                    Id = 5,
                    Title = "Marina Bay Sands",
                    SubTitle = "Luxury Hotel and Entertainment Complex",
                    Description = "Marina Bay Sands is an iconic luxury hotel and entertainment complex in Singapore, renowned for its distinctive architecture featuring three interconnected towers and a SkyPark. The complex includes a range of amenities such as the world's largest rooftop infinity pool, a museum, high-end shopping, dining options, a casino, and an observation deck with panoramic views of the city.",
                    Rooms = 2500,
                    NumberOfGuests = 5,
                    PricePerDay = 300,
                    Features = Features.Smoking,
                    LocationType = LocationType.Hotel,
                    LandlordId = 3
                },
                new Location
                {
                    Id = 6,
                    Title = "Marina Bay Sands",
                    SubTitle = "Luxury Hotel and Entertainment Complex",
                    Description = "Marina Bay Sands is an iconic luxury hotel and entertainment complex in Singapore, renowned for its distinctive architecture featuring three interconnected towers and a SkyPark. The complex includes a range of amenities such as the world's largest rooftop infinity pool, a museum, high-end shopping, dining options, a casino, and an observation deck with panoramic views of the city.",
                    Rooms = 2500,
                    NumberOfGuests = 5,
                    PricePerDay = 300,
                    Features = Features.Smoking,
                    LocationType = LocationType.Hotel,
                    LandlordId = 3
                },
                new Location
                {
                    Id = 7,
                    Title = "Marina Bay Sands",
                    SubTitle = "Luxury Hotel and Entertainment Complex",
                    Description = "Marina Bay Sands is an iconic luxury hotel and entertainment complex in Singapore, renowned for its distinctive architecture featuring three interconnected towers and a SkyPark. The complex includes a range of amenities such as the world's largest rooftop infinity pool, a museum, high-end shopping, dining options, a casino, and an observation deck with panoramic views of the city.",
                    Rooms = 2500,
                    NumberOfGuests = 5,
                    PricePerDay = 300,
                    Features = Features.Smoking,
                    LocationType = LocationType.Hotel,
                    LandlordId = 3
                },
                new Location
                {
                    Id = 8,
                    Title = "Marina Bay Sands",
                    SubTitle = "Luxury Hotel and Entertainment Complex",
                    Description = "Marina Bay Sands is an iconic luxury hotel and entertainment complex in Singapore, renowned for its distinctive architecture featuring three interconnected towers and a SkyPark. The complex includes a range of amenities such as the world's largest rooftop infinity pool, a museum, high-end shopping, dining options, a casino, and an observation deck with panoramic views of the city.",
                    Rooms = 2500,
                    NumberOfGuests = 5,
                    PricePerDay = 300,
                    Features = Features.Smoking,
                    LocationType = LocationType.Hotel,
                    LandlordId = 3
                },
                new Location
                {
                    Id = 9,
                    Title = "Marina Bay Sands",
                    SubTitle = "Luxury Hotel and Entertainment Complex",
                    Description = "Marina Bay Sands is an iconic luxury hotel and entertainment complex in Singapore, renowned for its distinctive architecture featuring three interconnected towers and a SkyPark. The complex includes a range of amenities such as the world's largest rooftop infinity pool, a museum, high-end shopping, dining options, a casino, and an observation deck with panoramic views of the city.",
                    Rooms = 2500,
                    NumberOfGuests = 5,
                    PricePerDay = 300,
                    Features = Features.Smoking,
                    LocationType = LocationType.Hotel,
                    LandlordId = 3
                },
                new Location
                {
                    Id = 10,
                    Title = "Marina Bay Sands",
                    SubTitle = "Luxury Hotel and Entertainment Complex",
                    Description = "Marina Bay Sands is an iconic luxury hotel and entertainment complex in Singapore, renowned for its distinctive architecture featuring three interconnected towers and a SkyPark. The complex includes a range of amenities such as the world's largest rooftop infinity pool, a museum, high-end shopping, dining options, a casino, and an observation deck with panoramic views of the city.",
                    Rooms = 2500,
                    NumberOfGuests = 2,
                    PricePerDay = 375,
                    Features = Features.Smoking,
                    LocationType = LocationType.Hotel,
                    LandlordId = 3
                }
                );
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = 1,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/4/4c/160322-066_View_from_Thiri.jpg",
                    IsCover = false,
                    LocationId = 1,
                },
                new Image
                {
                    Id = 2,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/b/bd/Broadway_Luxury_and_Eadburgha_House_-_geograph.org.uk_-_6093435.jpg",
                    IsCover = true,
                    LocationId = 2,
                },
                new Image
                {
                    Id = 3,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/9/95/President_Trump_Travels_to_Arizona_%2850041201672%29.jpg",
                    IsCover = false,
                    LocationId = 3,
                },
                new Image
                {
                    Id = 5,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/4/4c/160322-066_View_from_Thiri.jpg",
                    IsCover = true,
                    LocationId = 1,
                },
                new Image
                {
                    Id = 6,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/b/bd/Broadway_Luxury_and_Eadburgha_House_-_geograph.org.uk_-_6093435.jpg",
                    IsCover = true,
                    LocationId = 2,
                },
                
                // Elon musk landlord Image
                new Image
                {
                    Id = 7,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
                    IsCover = false,
                    LocationId = 1,
                    LandlordId = 1,
                },
                // Jeff Bezos Landlord image
                new Image
                {
                    Id = 8,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fb/Jeff_Bezos_2016_crop.jpg/640px-Jeff_Bezos_2016_crop.jpg",
                    IsCover = false,
                    LocationId = 2,
                    LandlordId = 2,
                },
                // Trump landlord image
                new Image
                {
                    Id = 9,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/0/0b/Donald_Trump_%2852250930172%29_%28cropped%29.jpg",
                    IsCover = false,
                    LocationId = 3,
                    LandlordId = 3,
                },
                new Image
                {
                    Id = 10,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/9/95/President_Trump_Travels_to_Arizona_%2850041201672%29.jpg",
                    IsCover = true,
                    LocationId = 3,
                },
                // 1st pic location 4
                new Image
                {
                    Id = 11,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/7/7e/Cricket_match_and_Marina_Bay_Sands_Hotel_in_Singapore.jpg",
                    IsCover = true,
                    LocationId = 4,
                },
                // 2nd pic location 4
                new Image
                {
                    Id = 12,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/5/57/Singapore_%28SG%29%2C_ArtScience_Museum_and_Marina_Bay_Sands_Hotel_--_2019_--_4695.jpg",
                    IsCover = false,
                    LocationId = 4,
                }
                );
            modelBuilder.Entity<Landlord>().HasData(
                new Landlord
                {
                    Id = 1,
                    FirstName = "Koen",
                    LastName = "Hoeven",
                    Age = 20,
                },
                new Landlord
                {
                    Id = 2,
                    FirstName = "Jan",
                    LastName = "Jansen",
                    Age = 32,
                },
                new Landlord
                {
                    Id = 3,
                    FirstName = "Donald",
                    LastName = "Trumpet",
                    Age = 90,
                }
                );
        }
    }
}
