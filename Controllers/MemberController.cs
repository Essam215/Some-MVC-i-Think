using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagmentSystem.Controllers
{
    public class MemberController : Controller
    {
        private readonly IGenericRepo<Member> _context;

        public MemberController(IGenericRepo<Member> context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Member member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }
            _context.Create(member);
            _context.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var member = _context.GetById(id);

            if (member == null) return NotFound();

            return View(member);
        }

        [HttpPost]

        public IActionResult Edit(Member member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }
            _context.Update(member);
            _context.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var member = _context.GetById(id);

            if (member == null) return NotFound();

            return View(member);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            var member = _context.GetById(id);
            if (member == null) return NotFound();

            _context.Delete(member);
            _context.Save();

            return RedirectToAction("Index");
        }
    }
}
