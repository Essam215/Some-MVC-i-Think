using ClubManagmentSystem.Models;

namespace ClubManagmentSystem.Repo.Interfaces
{
    public interface IActivityRepo : IGenericRepo<Activityy>
    {
        List<Activityy> Search(string input);
    }
}
