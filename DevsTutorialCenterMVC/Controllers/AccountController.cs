using DevsTutorialCenterMVC.Data.Entities;
using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult WithAccount()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ResetPassword(string Email, string token)
        {
            var viewModel = new ResetPasswordViewModel();
            if (string.IsNullOrEmpty(token))
            {
                ViewBag.ErrToken = "";
            }

            if (string.IsNullOrEmpty(Email))
            {
                ViewBag.ErrEmail = "Email is required";
            }

            viewModel.Token = token;
            viewModel.Email = Email;

            return View(viewModel);
        }



        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError(err.Code, err.Description);
                    }
                }
                else
                {
                    ViewBag.ErrEmail = "Email not found";
                }
            }

            return View(model);
        }

    }
}

