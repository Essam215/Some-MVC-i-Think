using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required]
        public string? Type { get; set; } // Regular / VIP

        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        public int EventId { get; set; }

        // Navigation
        public Event ?Event { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
