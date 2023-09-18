using DevsTutorialCenterMVC.Data.Entities;
using DevsTutorialCenterMVC.Data.Repositories;
using DevsTutorialCenterMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository _repository;

        public AccountController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp(
            string token,
            string Firstname,
            string Lastname,
            string email,
            string Userstack,
            string Squadnumber)
        {

            var model = new SignUpViewModel
            {
                Token = token,
                FirstName = Firstname,
                LastName = Lastname,
                Email = email,
                SquadNumber = int.Parse(Squadnumber),
                Stack = Userstack
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var users = (await _repository.GetAllAsync<AppUser>()).ToList();

            if (users.Any(user => user.Email == model.Email))
            {
                ModelState.AddModelError("User Exist", "This account already exist");

                return View(model);
            }

            await _repository.AddAsync(new AppUser
            {
                FirstName = model.FirstName,
                LastName= model.LastName,
                Email = model.Email,
                UserName = model.Email
            });

            users = (await _repository.GetAllAsync<AppUser>()).ToList();

            if (users.Any(user => user.Email == model.Email))
            {
                TempData["isSaved"] = true;
                return RedirectToAction("Login");
            }
            return BadRequest();
            
        }

        public IActionResult WithAccount()
        {
            return View();
        }
    }
}
