using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EindOpdracht.Migrations
{
    /// <inheritdoc />
    public partial class LastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Landlords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<float>(type: "real", nullable: false),
                    Features = table.Column<int>(type: "int", nullable: false),
                    LocationType = table.Column<int>(type: "int", nullable: false),
                    LandlordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCover = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    LandlordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Landlords",
                columns: new[] { "Id", "Age", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 20, "Koen", "Hoeven" },
                    { 2, 32, "Jan", "Jansen" },
                    { 3, 90, "Donald", "Trumpet" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "Features", "LandlordId", "LocationType", "NumberOfGuests", "PricePerDay", "Rooms", "SubTitle", "Title" },
                values: new object[,]
                {
                    { 1, "De camping ligt verscholen achter de boerderij in de polder. Op fietsafstand (5 minuten) liggen het dorpje Nieuwvliet, de zee, het strand, het bos van Erasmus en het natuurgebied de Knokkert.", 43, 1, 1, 5, 500f, 5, "Lekker veel ruimte", "De Boerenhoeve" },
                    { 2, "Nee, dit puike penthouse dat al jaren te koop stond en nu is verkocht, is niet de duurste woning van ons land. Bij lange na niet. Wel is de meer dan €30.000 per vierkante meter woonruimte een record in ons land.", 60, 2, 5, 5, 2000f, 5, "Te gek uitzicht", "Frankie's Penthouse" },
                    { 3, "This powerful barrier is a vital step in securing our nation’s borders. By stopping illegal immigration, drugs, and crime, we are protecting the American people and upholding our laws. The Great American Wall stands as a symbol of strength, sovereignty, and the unwavering resolve of the United States to maintain its integrity and safety.", 3, 3, 3, 5, 5f, 5, "The Great American Wall", "Trump's Wall" },
                    { 4, "Marina Bay Sands is an iconic luxury hotel and entertainment complex in Singapore, renowned for its distinctive architecture featuring three interconnected towers and a SkyPark. The complex includes a range of amenities such as the world's largest rooftop infinity pool, a museum, high-end shopping, dining options, a casino, and an observation deck with panoramic views of the city.", 60, 3, 4, 5, 600f, 2500, "Luxury Hotel and Entertainment Complex", "Marina Bay Sands" },
                    { 5, "Nestled along the picturesque coastline of Singapore, NSRCC Chalets offer a tranquil escape within the National Service Resort & Country Club complex. These chalets are designed for comfort and relaxation, providing a perfect blend of leisure and activity. Guests can enjoy modern amenities, spacious accommodations, and direct access to extensive golfing facilities. The serene setting is enhanced by stunning views of lush greenery and the sea, making it an ideal location for family vacations, golf retreats, and private gatherings.", 1, 1, 2, 5, 750f, 2500, "Relaxing Retreat with Scenic Golf Views", "NSRCC Chalets: Serene Getaway by the Sea" },
                    { 6, "Harborview Residences offers a premium living experience in its modern apartment complex, strategically located to combine urban convenience with breathtaking views. This complex features a range of thoughtfully designed apartments that cater to diverse lifestyles, from bustling singles to growing families. Residents enjoy top-notch amenities including a fitness center, swimming pool, landscaped gardens, and a community clubhouse. The secure environment is complemented by easy access to local shopping, dining, and entertainment options, ensuring a balanced and vibrant lifestyle.", 1, 2, 0, 5, 200f, 2500, "Contemporary Apartments with Panoramic Cityscapes", "Harborview Residences: Modern Living Redefined" },
                    { 7, "Trump Tower stands as a symbol of luxury and power in the heart of New York City. This prestigious mixed-use skyscraper features a striking facade of reflective glass, housing 2500 rooms that include upscale residential units and corporate offices. The tower is known for its lavish interiors, including a six-story atrium adorned with pink marble and a 60-foot waterfall. Residents and visitors can enjoy first-rate amenities such as high-end shopping boutiques, fine dining restaurants, and exclusive access areas, all representing the pinnacle of urban opulence.", 1, 3, 0, 5, 100f, 2500, "Prestigious Residence and Business Hub", "Trump Tower: Urban Opulence Redefined" },
                    { 8, "Marina Bay Sands is an iconic luxury hotel and entertainment complex in Singapore, renowned for its distinctive architecture featuring three interconnected towers and a SkyPark. The complex includes a range of amenities such as the world's largest rooftop infinity pool, a museum, high-end shopping, dining options, a casino, and an observation deck with panoramic views of the city.", 1, 2, 4, 5, 185f, 2500, "Luxury Hotel and Entertainment Complex", "Marina Bay Sands" },
                    { 9, "Marina Bay Sands is an iconic luxury hotel and entertainment complex in Singapore, renowned for its distinctive architecture featuring three interconnected towers and a SkyPark. The complex includes a range of amenities such as the world's largest rooftop infinity pool, a museum, high-end shopping, dining options, a casino, and an observation deck with panoramic views of the city.", 1, 1, 4, 5, 300f, 2500, "Luxury Hotel and Entertainment Complex", "Marina Bay Sands" },
                    { 10, "Marina Bay Sands is an iconic luxury hotel and entertainment complex in Singapore, renowned for its distinctive architecture featuring three interconnected towers and a SkyPark. The complex includes a range of amenities such as the world's largest rooftop infinity pool, a museum, high-end shopping, dining options, a casino, and an observation deck with panoramic views of the city.", 24, 1, 4, 2, 375f, 2500, "Luxury Hotel and Entertainment Complex", "Marina Bay Sands" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsCover", "LandlordId", "LocationId", "Url" },
                values: new object[,]
                {
                    { 1, false, null, 1, "https://upload.wikimedia.org/wikipedia/commons/4/4c/160322-066_View_from_Thiri.jpg" },
                    { 2, true, null, 2, "https://upload.wikimedia.org/wikipedia/commons/b/bd/Broadway_Luxury_and_Eadburgha_House_-_geograph.org.uk_-_6093435.jpg" },
                    { 3, false, null, 3, "https://upload.wikimedia.org/wikipedia/commons/9/95/President_Trump_Travels_to_Arizona_%2850041201672%29.jpg" },
                    { 5, true, null, 1, "https://upload.wikimedia.org/wikipedia/commons/4/4c/160322-066_View_from_Thiri.jpg" },
                    { 6, true, null, 2, "https://upload.wikimedia.org/wikipedia/commons/b/bd/Broadway_Luxury_and_Eadburgha_House_-_geograph.org.uk_-_6093435.jpg" },
                    { 7, false, 1, 1, "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg" },
                    { 8, false, 2, 2, "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fb/Jeff_Bezos_2016_crop.jpg/640px-Jeff_Bezos_2016_crop.jpg" },
                    { 9, false, 3, 3, "https://upload.wikimedia.org/wikipedia/commons/0/0b/Donald_Trump_%2852250930172%29_%28cropped%29.jpg" },
                    { 10, true, null, 3, "https://upload.wikimedia.org/wikipedia/commons/9/95/President_Trump_Travels_to_Arizona_%2850041201672%29.jpg" },
                    { 11, true, null, 4, "https://upload.wikimedia.org/wikipedia/commons/7/7e/Cricket_match_and_Marina_Bay_Sands_Hotel_in_Singapore.jpg" },
                    { 12, false, null, 4, "https://upload.wikimedia.org/wikipedia/commons/5/57/Singapore_%28SG%29%2C_ArtScience_Museum_and_Marina_Bay_Sands_Hotel_--_2019_--_4695.jpg" },
                    { 13, true, null, 5, "https://www.nsrcc.com.sg/sites/nsrcc.d8.mx.sg/files/block-images/Home_Bungalow.jpg" },
                    { 14, true, null, 6, "https://upload.wikimedia.org/wikipedia/commons/1/14/Appartement_Chateau_Saint-Louis_04.jpg" },
                    { 15, true, null, 7, "https://upload.wikimedia.org/wikipedia/commons/f/fa/Trump_Tower_Entrance_2015-08.jpg" },
                    { 16, true, null, 8, "https://upload.wikimedia.org/wikipedia/commons/7/7e/Cricket_match_and_Marina_Bay_Sands_Hotel_in_Singapore.jpg" },
                    { 17, false, null, 8, "https://upload.wikimedia.org/wikipedia/commons/5/57/Singapore_%28SG%29%2C_ArtScience_Museum_and_Marina_Bay_Sands_Hotel_--_2019_--_4695.jpg" },
                    { 18, true, null, 9, "https://upload.wikimedia.org/wikipedia/commons/7/7e/Cricket_match_and_Marina_Bay_Sands_Hotel_in_Singapore.jpg" },
                    { 19, false, null, 9, "https://upload.wikimedia.org/wikipedia/commons/5/57/Singapore_%28SG%29%2C_ArtScience_Museum_and_Marina_Bay_Sands_Hotel_--_2019_--_4695.jpg" },
                    { 20, true, null, 10, "https://upload.wikimedia.org/wikipedia/commons/7/7e/Cricket_match_and_Marina_Bay_Sands_Hotel_in_Singapore.jpg" },
                    { 21, false, null, 10, "https://upload.wikimedia.org/wikipedia/commons/5/57/Singapore_%28SG%29%2C_ArtScience_Museum_and_Marina_Bay_Sands_Hotel_--_2019_--_4695.jpg" },
                    { 22, false, null, 5, "https://upload.wikimedia.org/wikipedia/commons/5/57/Singapore_%28SG%29%2C_ArtScience_Museum_and_Marina_Bay_Sands_Hotel_--_2019_--_4695.jpg" },
                    { 23, false, null, 6, "https://upload.wikimedia.org/wikipedia/commons/5/57/Singapore_%28SG%29%2C_ArtScience_Museum_and_Marina_Bay_Sands_Hotel_--_2019_--_4695.jpg" },
                    { 24, false, null, 7, "https://upload.wikimedia.org/wikipedia/commons/5/57/Singapore_%28SG%29%2C_ArtScience_Museum_and_Marina_Bay_Sands_Hotel_--_2019_--_4695.jpg" },
                    { 25, false, null, 2, "https://upload.wikimedia.org/wikipedia/commons/b/bd/Broadway_Luxury_and_Eadburgha_House_-_geograph.org.uk_-_6093435.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_LandlordId",
                table: "Images",
                column: "LandlordId",
                unique: true,
                filter: "[LandlordId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_LocationId",
                table: "Images",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LandlordId",
                table: "Locations",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LocationId",
                table: "Reservations",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Landlords");
        }
    }
}
