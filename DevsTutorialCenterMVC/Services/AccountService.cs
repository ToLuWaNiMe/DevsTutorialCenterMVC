using DevsTutorialCenterMVC.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DevsTutorialCenterMVC.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public bool IsLoggedInAsync(ClaimsPrincipal user)
        {
            if (_signInManager.IsSignedIn(user))
                return true;
            return false;
        }
    }
}
