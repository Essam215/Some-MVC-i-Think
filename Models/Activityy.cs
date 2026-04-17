using System.ComponentModel.DataAnnotations;

namespace ClubManagmentSystem.Models
{
    public class Activityy
    {
        [Key]
        public int ActivityId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public int Duration { get; set; }

        // Navigation Property
        public List<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
