namespace EindOpdracht.DTO.Exchange
{
    public class ReservationsExchange
    {
    }
    public class ReservationRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public float? Discount { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ReservationResponseDto
    {
        public string LocationName { get; set; }
        public string CustomerName { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
    }
}
