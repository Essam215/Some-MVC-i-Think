using ClinicSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [MaxLength(25)]
        [Required]
        public string Name { get; set; } = string.Empty;
        public Specialization specialization { get; set; }
        public List<Appointment> Appointments { get; set; } = new();

    }
}
