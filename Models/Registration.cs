using System.ComponentModel.DataAnnotations;

namespace ClubManagmentSystem.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }

        public DateTime RegistrationDate { get; set; }

        // FK
        public int MemberId { get; set; }
        public int ActivityId { get; set; }

        // Navigation
        public Member Member { get; set; }
        public Activityy Activity { get; set; }
    }
}
