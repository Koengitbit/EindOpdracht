namespace EindOpdracht.DTO
{
    public class LocationDetailsDTO
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int Rooms { get; set; }
        public int NumberOfGuests { get; set; }
        public float PricePerDay { get; set; }
        public int Type { get; set; }
        public int Features { get; set; }
        public List<ImageDTO> Images { get; set; }
        public LandlordDTO Landlord { get; set; }
    }
}
