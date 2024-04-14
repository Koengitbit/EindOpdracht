using System.Reflection.Metadata;

namespace EindOpdracht.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsCover { get; set; }
        public int? LocationId { get; set; }
        public Location? Location { get; set; } = null!;
        public int? LandlordId { get; set; }
        public Landlord? Landlord { get; set; } = null!;
    }
}
