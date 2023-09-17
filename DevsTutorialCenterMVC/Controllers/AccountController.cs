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
        private readonly IAccountService _accountService;
        private readonly IMessengerService _messengerService;
        private readonly IConfiguration _config;

        public AccountController(UserManager<AppUser> userManager, IAccountService accountService,
            IMessengerService messengerService, IConfiguration config)
        {
            _userManager = userManager;
            _accountService = accountService;
            _messengerService = messengerService;
            _config = config;
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
        public IActionResult ForgotPassword()
        {
            if (_accountService.IsLoggedInAsync(User))
                return RedirectToAction("Index", "Home");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (_accountService.IsLoggedInAsync(User))
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(xx => xx.ErrorMessage));
                var error = string.Join(" ", errors);
                ViewBag.Err = error;
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ViewBag.Err = "Email does not exist";
                return View(model);
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action("ResetPassword", "Account", new { token, model.Email }, Request.Scheme);
            var sender = _config.GetSection("EmailSettings")["SenderEmail"];
            var message = new Message("Reset Password link", new List<string>() { model.Email }, $"<a href=\"{link}\">Reset password</a>");

            var messageStatus = _messengerService.Send(message);

            ViewBag.Err = messageStatus == ""
                ? "A reset password link has been sent to the email provided. Please go to your inbox and click on the link t reset your password"
                : "Failed to send a reset password link. Please try again";

            return View(model);
        }
    }
}
