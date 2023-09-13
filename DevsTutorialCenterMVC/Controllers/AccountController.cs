using DevsTutorialCenterMVC.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string id, string token)
        {
            // if id or token is null, end the process
            if (id == null || token == null)
            {
                ViewBag.ErrorTitle = "Invalid Id or token";
                ViewBag.ErrorMessage = $"User or token cannot be null";
                return View("Error");
            }

            // ensure that user exist
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id {id} cannot be found!";
                return View("NotFound");
            }

            // confirm email
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }

            // on failure
            ViewBag.ErrorTitle = "Conirmation Failed";
            ViewBag.ErrorMessage = $"Could not confirm email.";
            return View("Error");

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
    }
}
