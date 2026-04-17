using ClubManagmentSystem.Context;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repo.Interfaces;

namespace ClubManagmentSystem.Repo.Implementations
{
    public class MemberRepo : IGenericRepo<Member>
    {
        private readonly MyDbContext _context;

        public MemberRepo(MyDbContext context)
        {
            _context = context;
        }

        public void Create(Member entity)
        {
            _context.Members.Add(entity);
        }

        public void Delete(Member entity)
        {
            _context.Members.Remove(entity);
        }

        public List<Member> GetAll()
        {
            return _context.Members.ToList();
        }

        public Member GetById(int id)
        {
            return _context.Members.Where(m => m.MemberId == id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Member entity)
        {
            _context.Members.Update(entity);
        }
    }
}
