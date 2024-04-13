namespace EindOpdracht.Models
{
    [Flags]
    public enum Features
    {
        Smoking = 1,
        PetsAllowed = 2,
        Wifi = 4,
        TV = 8,
        Bath = 16,
        Breakfast = 32
    }

    public enum LocationType
    {
        Appartment,
        Cottage,
        Chalet,
        Room,
        Hotel,
        House
    }
    public class Location
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int Rooms { get; set; }
        public int NumberOfGuests { get; set; }
        public float PricePerDay { get; set; }
        public Features Features { get; set; }
        public LocationType LocationType { get; set; }
        public ICollection<Image> Images { get; } = new List<Image>();
        public ICollection<Reservation> Reservations { get; } = new List<Reservation>();
        public Landlord Landlord { get; set; }
    }
}
