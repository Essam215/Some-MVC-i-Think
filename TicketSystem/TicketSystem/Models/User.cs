using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string ?Name { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 15, ErrorMessage = "Phone number from 9 to 15")]
        public string ?Phone { get; set; }


        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
