using TicketSystem.Models;
using TicketSystem.Repo.Interfaces;

namespace TicketSystem.Repo.Implementations
{
    public class TicketRepo : IGenericRepo<Ticket>
    {
        private readonly MyDbContext _context;

        public TicketRepo(MyDbContext context)
        {
            _context = context;
        }

        public void Add(Ticket entity)
        {
            _context.Tickets.Add(entity);
        }

        public void Delete(Ticket entity)
        {
            _context.Tickets.Remove(entity);
        }

        public List<Ticket> GetAll()
        {
            return _context.Tickets.ToList();
        }

        public Ticket? GetById(int id)
        {
            return _context.Tickets.FirstOrDefault(t => t.TicketId == id);
        }

        public void Update(Ticket entity)
        {
            _context.Tickets.Update(entity);
        }
    }
}
