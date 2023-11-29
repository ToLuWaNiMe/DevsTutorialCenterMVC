using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;
        private readonly IConfiguration _config;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            if (email == null || token == null)
            {
                ViewBag.ErrorTitle = "Invalid Id or token";
                ViewBag.ErrorMessage = $"User or token cannot be null";
                return View("Error");
            }

            ViewBag.ErrorTitle = "Conirmation Failed";
            ViewBag.ErrorMessage = $"Could not confirm email.";
            return View("Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _authService.Login(model);

            if (result.IsFailure)
                return View(model);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            var authResponse = await _authService.Register(model);
            if (authResponse.IsFailure)
                return BadRequest();
            
            return RedirectToAction("Login");
        }

        public IActionResult WithAccount()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(xx => xx.ErrorMessage));
                var error = string.Join(" ", errors);
                ViewBag.Err = error;
                return View(model);
            }

            return View(model);
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
            if (!ModelState.IsValid)
                return View(model);

            return View(model);
        }
    }
}