namespace EindOpdracht.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsCover { get; set; }
        public Location? Locations { get; set; }
        public int? LandlordId { get; set; }
        public Landlord? Landlords { get; set; }
    }
}
