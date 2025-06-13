using GacusanIII_UserManagement.Context;
using GacusanIII_UserManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GacusanIII_UserManagement.Controllers
{
    public class PersonController : Controller
    {
        private readonly MyDBContext _dbContext;

        public PersonController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var persons = _dbContext.Persons.ToList();
            return View(persons);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(PersonUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = model.Role
                };

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                var person = new Person
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Email = model.Email,
                    DateCreated = DateTime.Now,
                    UserId = user.Id
                };

                _dbContext.Persons.Add(person);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Update(int id)
        {
            var person = _dbContext.Persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
                return NotFound();

            var user = _dbContext.Users.FirstOrDefault(u => u.Id == person.UserId);
            if (user == null)
                return NotFound();

            var viewModel = new PersonUserViewModel
            {
                PersonId = person.Id,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                Email = person.Email,
                UserId = user.Id,
                Username = user.Username,
                Password = user.Password,
                Role = user.Role
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PersonUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var person = _dbContext.Persons.FirstOrDefault(p => p.Id == model.PersonId);
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == model.UserId);

            if (person == null || user == null)
                return NotFound();

            person.Firstname = model.Firstname;
            person.Lastname = model.Lastname;
            person.Email = model.Email;
            person.DateUpdated = DateTime.Now;

            user.Username = model.Username;
            user.Password = model.Password;
            user.Role = model.Role;

            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var person = _dbContext.Persons.Find(id);
            if (person == null)
                return NotFound();

            _dbContext.Persons.Remove(person);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
