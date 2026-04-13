using TicketSystem.Models;
using TicketSystem.Repo.Interfaces;
namespace TicketSystem.Repo.Implementations
{
    public class UserRepo : IGenericRepo<User>
    {
        private readonly MyDbContext _context;

        public UserRepo(MyDbContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }
    }
}
