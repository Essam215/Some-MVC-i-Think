using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repo.Interfaces;
using ClubManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagmentSystem.Controllers
{
    public class RegistrationController : Controller
    {

        private readonly IGenericRepo<Registration> _context;
        private readonly IGenericRepo<Member> _memberRepo;
        private readonly IActivityRepo _activityRepo;

        public RegistrationController(IGenericRepo<Registration> context, IGenericRepo<Member> memberRepo, IActivityRepo activityRepo)
        {
            _context = context;
            _memberRepo = memberRepo;
            _activityRepo = activityRepo;
        }

        public IActionResult Index()
        {
            var registrations = _context.GetAll();
            return View(registrations);
        }

        public IActionResult Create()
        {
            var vm = new RegistrationVM()
            {
                members = _memberRepo.GetAll(),
                activities = _activityRepo.GetAll(),
            };

            return View(vm);
        }

        [HttpPost]

        public IActionResult Create(RegistrationVM vm)
        {
            var res = new Registration()
            {
                RegistrationId = vm.Id,
                MemberId = vm.MemberId,
                ActivityId = vm.ActivityId,
                RegistrationDate = vm.RegistrationDate
            };
            _context.Create(res);
            _context.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var registration = _context.GetById(id);
            var vm = new RegistrationVM()
            {
                Id = registration.RegistrationId,
                RegistrationDate = registration.RegistrationDate,
                MemberId = registration.MemberId,
                ActivityId = registration.ActivityId,
                activities = _activityRepo.GetAll(),
                members = _memberRepo.GetAll()
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(RegistrationVM vm)
        {

            var registration = new Registration()
            {
                RegistrationId = vm.Id,
                RegistrationDate = vm.RegistrationDate,
                MemberId = vm.MemberId,
                ActivityId = vm.ActivityId,
                Member = _memberRepo.GetById(vm.MemberId),
                Activity = _activityRepo.GetById(vm.ActivityId),
            };
            _context.Update(registration);
            _context.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var registration = _context.GetById(id);

            if (registration == null) return NotFound();

            return View(registration);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            var registration = _context.GetById(id);

            if (registration == null) return NotFound();

            _context.Delete(registration);
            _context.Save();

            return RedirectToAction("Index");
        }

    }
}
