using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace TicketSystem.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        public string ?Title { get; set; }

        [Required]
        public string ?Location { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
        public int Capacity { get; set; }

        // Navigation
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
