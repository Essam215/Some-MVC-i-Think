using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClubManagmentSystem.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityRepo _context;

        public ActivityController(IActivityRepo context)
        {
            _context = context;
        }

        public IActionResult Index(string input)
        {
            return View(string.IsNullOrEmpty(input) ? _context.GetAll() : _context.Search(input));

            //if (string.IsNullOrEmpty(input)) {
            //    return View(_context.GetAll());
            //}
            //else {
            //    return View(_context.Search(input));
            //}
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Activityy activityy)
        {
            if (!ModelState.IsValid)
            {
                return View(activityy);
            }
            _context.Create(activityy);
            _context.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var activity = _context.GetById(id);

            if (activity == null) return NotFound();

            return View(activity);
        }

        [HttpPost]

        public IActionResult Edit(Activityy activity)
        {
            if (!ModelState.IsValid)
            {
                return View(activity);
            }
            _context.Update(activity);
            _context.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var activity = _context.GetById(id);

            if (activity == null) return NotFound();

            return View(activity);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            var activity = _context.GetById(id);
            if (activity == null) return NotFound();

            _context.Delete(activity);
            _context.Save();

            return RedirectToAction("Index");
        }
    }
}
