using System.Reflection.Metadata;

namespace EindOpdracht.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ReservationId { get; set; }
        public ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    }
}
