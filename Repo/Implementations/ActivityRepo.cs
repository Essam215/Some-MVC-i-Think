using ClubManagmentSystem.Context;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repo.Interfaces;

namespace ClubManagmentSystem.Repo.Implementations
{
    public class ActivityRepo : IActivityRepo
    {

        private readonly MyDbContext _context;

        public ActivityRepo(MyDbContext context)
        {
            _context = context;
        }
        public void Create(Activityy entity)
        {
            _context.Activityys.Add(entity);
        }

        public void Delete(Activityy entity)
        {
            _context.Activityys.Remove(entity);
        }

        public List<Activityy> GetAll()
        {
            return _context.Activityys.ToList();
        }

        public Activityy GetById(int id)
        {
            return _context.Activityys.Where(a => a.ActivityId == id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<Activityy> Search(string input)
        {
            var activities = _context.Activityys.AsQueryable();
            activities = activities.Where(a => a.Name.ToLower().Contains(input.ToLower()));
            return activities.ToList();
        }

        public void Update(Activityy entity)
        {
            _context.Activityys.Update(entity);
        }
    }
}
