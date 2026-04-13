using System.ComponentModel.DataAnnotations;

namespace ClinicSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [StringLength(15, MinimumLength = 10)]
        public string? Phone { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
    }
}
