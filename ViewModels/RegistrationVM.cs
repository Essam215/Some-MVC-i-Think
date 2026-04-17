using ClubManagmentSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace ClubManagmentSystem.ViewModels
{
    public class RegistrationVM
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int MemberId { get; set; }
        public int ActivityId { get; set; }
        public List<Member> members { get; set; } = new();
        public List<Activityy> activities { get; set; } = new();    
    }
}
