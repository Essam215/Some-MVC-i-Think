using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{

    public class Booking
    {
        public int BookingId { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public int UserId { get; set; }
        public int TicketId { get; set; }

        // Navigation
        public User ?User { get; set; }
        public Ticket ?Ticket { get; set; }
    }
}
