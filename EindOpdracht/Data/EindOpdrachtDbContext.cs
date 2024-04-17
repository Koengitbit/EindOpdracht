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
                    Features = Features.Smoking | Features.PetsAllowed | Features.TV | Features.Breakfast, // Can hold multiple enums
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
                    Features = Features.Wifi | Features.TV | Features.Breakfast | Features.Bath,
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
                    Features = Features.Smoking | Features.PetsAllowed,
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
                    PricePerDay = 600,
                    Features = Features.Wifi | Features.TV | Features.Breakfast | Features.Bath,
                    LocationType = LocationType.Hotel,
                    LandlordId = 3
                },
                new Location
                {
                    Id = 5,
                    Title = "NSRCC Chalets: Serene Getaway by the Sea",
                    SubTitle = "Relaxing Retreat with Scenic Golf Views",
                    Description = "Nestled along the picturesque coastline of Singapore, NSRCC Chalets offer a tranquil escape within the National Service Resort & Country Club complex. These chalets are designed for comfort and relaxation, providing a perfect blend of leisure and activity. Guests can enjoy modern amenities, spacious accommodations, and direct access to extensive golfing facilities. The serene setting is enhanced by stunning views of lush greenery and the sea, making it an ideal location for family vacations, golf retreats, and private gatherings.",
                    Rooms = 2500,
                    NumberOfGuests = 5,
                    PricePerDay = 750,
                    Features = Features.Smoking,
                    LocationType = LocationType.Chalet,
                    LandlordId = 1
                },
                new Location
                {
                    Id = 6,
                    Title = "Harborview Residences: Modern Living Redefined",
                    SubTitle = "Contemporary Apartments with Panoramic Cityscapes",
                    Description = "Harborview Residences offers a premium living experience in its modern apartment complex, strategically located to combine urban convenience with breathtaking views. This complex features a range of thoughtfully designed apartments that cater to diverse lifestyles, from bustling singles to growing families. Residents enjoy top-notch amenities including a fitness center, swimming pool, landscaped gardens, and a community clubhouse. The secure environment is complemented by easy access to local shopping, dining, and entertainment options, ensuring a balanced and vibrant lifestyle.",
                    Rooms = 2500,
                    NumberOfGuests = 5,
                    PricePerDay = 200,
                    Features = Features.Smoking,
                    LocationType = LocationType.Appartment,
                    LandlordId = 2
                },
                new Location
                {
                    Id = 7,
                    Title = "Trump Tower: Urban Opulence Redefined",
                    SubTitle = "Prestigious Residence and Business Hub",
                    Description = "Trump Tower stands as a symbol of luxury and power in the heart of New York City. This prestigious mixed-use skyscraper features a striking facade of reflective glass, housing 2500 rooms that include upscale residential units and corporate offices. The tower is known for its lavish interiors, including a six-story atrium adorned with pink marble and a 60-foot waterfall. Residents and visitors can enjoy first-rate amenities such as high-end shopping boutiques, fine dining restaurants, and exclusive access areas, all representing the pinnacle of urban opulence.",
                    Rooms = 2500,
                    NumberOfGuests = 5,
                    PricePerDay = 100,
                    Features = Features.Smoking,
                    LocationType = LocationType.Appartment,
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
                    PricePerDay = 185,
                    Features = Features.Smoking,
                    LocationType = LocationType.Hotel,
                    LandlordId = 2
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
                    LandlordId = 1
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
                    Features = Features.TV | Features.Bath,
                    LocationType = LocationType.Hotel,
                    LandlordId = 1
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
                },
                new Image
                {
                    Id = 13,
                    Url = "https://www.nsrcc.com.sg/sites/nsrcc.d8.mx.sg/files/block-images/Home_Bungalow.jpg",
                    IsCover = true,
                    LocationId = 5,
                },
                new Image
                {
                    Id = 14,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/1/14/Appartement_Chateau_Saint-Louis_04.jpg",
                    IsCover = true,
                    LocationId = 6,
                },
                new Image
                {
                    Id = 15,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/f/fa/Trump_Tower_Entrance_2015-08.jpg",
                    IsCover = true,
                    LocationId = 7,
                },
                // 1st pic location 8
                new Image
                {
                    Id = 16,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/7/7e/Cricket_match_and_Marina_Bay_Sands_Hotel_in_Singapore.jpg",
                    IsCover = true,
                    LocationId = 8,
                },
                // 2nd pic location 8
                new Image
                {
                    Id = 17,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/5/57/Singapore_%28SG%29%2C_ArtScience_Museum_and_Marina_Bay_Sands_Hotel_--_2019_--_4695.jpg",
                    IsCover = false,
                    LocationId = 8,
                },
                // 1st pic location 9
                new Image
                {
                    Id = 18,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/7/7e/Cricket_match_and_Marina_Bay_Sands_Hotel_in_Singapore.jpg",
                    IsCover = true,
                    LocationId = 9,
                },
                // 2nd pic location 9
                new Image
                {
                    Id = 19,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/5/57/Singapore_%28SG%29%2C_ArtScience_Museum_and_Marina_Bay_Sands_Hotel_--_2019_--_4695.jpg",
                    IsCover = false,
                    LocationId = 9,
                },
                // 1st pic location 10
                new Image
                {
                    Id = 20,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/7/7e/Cricket_match_and_Marina_Bay_Sands_Hotel_in_Singapore.jpg",
                    IsCover = true,
                    LocationId = 10,
                },
                // 2nd pic location 10
                new Image
                {
                    Id = 21,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/5/57/Singapore_%28SG%29%2C_ArtScience_Museum_and_Marina_Bay_Sands_Hotel_--_2019_--_4695.jpg",
                    IsCover = false,
                    LocationId = 10,
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
