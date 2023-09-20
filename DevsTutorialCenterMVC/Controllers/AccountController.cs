using DevsTutorialCenterMVC.Data.Entities;
using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using DevsTutorialCenterMVC.Data.Entities;
using DevsTutorialCenterMVC.Data.Repositories;
using DevsTutorialCenterMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DevsTutorialCenterMVC.Services;

namespace DevsTutorialCenterMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly IMessengerService _messengerService;
        private readonly IConfiguration _config;
        private readonly IRepository _repository;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AccountController> logger,
            IAccountService accountService,
            IMessengerService messengerService,
            IConfiguration config,
            IRepository repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _accountService = accountService;
            _messengerService = messengerService;
            _config = config;
            _repository = repository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            // if id or token is null, end the process
            if (email == null || token == null)
            {
                ViewBag.ErrorTitle = "Invalid Id or token";
                ViewBag.ErrorMessage = $"User or token cannot be null";
                return View("Error");
            }

            // ensure that user exist
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id {email} cannot be found!";
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpGet]
        public IActionResult SignUp(
            string token = "",
            string Firstname = "",
            string Lastname = "",
            string email = "",
            string Userstack = "",
            string Squadnumber = "0")
        {
            if (token == "")
            {
                return BadRequest("Access Denied");
            }

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
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email,
                    model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
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

