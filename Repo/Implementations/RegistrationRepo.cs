using ClubManagmentSystem.Context;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repo.Interfaces;
using ClubManagmentSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ClubManagmentSystem.Repo.Implementations
{
    public class RegistrationRepo : IGenericRepo<Registration>
    {

        private readonly MyDbContext _context;

        public RegistrationRepo(MyDbContext context)
        {
            _context = context;
        }
        public void Create(Registration entity)
        {
            _context.Registrations.Add(entity);
        }

        public void Delete(Registration entity)
        {
            _context.Registrations.Remove(entity);
        }

        public List<Registration> GetAll()
        {
            var r = _context.Registrations.Include(r => r.Activity).Include(r => r.Member).ToList();
            return r;
        }

        public Registration GetById(int id)
        {
            return _context.Registrations.Where(m => m.RegistrationId == id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Registration entity)
        {
            _context.Registrations.Update(entity);
        }
    }
}
