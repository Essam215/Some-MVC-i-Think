using System.ComponentModel.DataAnnotations;

namespace ClubManagmentSystem.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Phone { get; set; } = string.Empty;

        // Navigation Property
        public List<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
