using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace DevsTutorialCenterMVC.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAccountService _accountService;

        public AdminController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<IActionResult> Index(AccountDetailsViewModel account)
        {
            var viewModelList = await _accountService.GetAllAccountsAsync(account);
          
            return View(viewModelList);
        }



     
    public async Task<IActionResult> AccountDetails(string id)
        {

            var account = await _accountService.AccountsDetailsAsync(id);
            if (account == null)
            {
                return NotFound(); 
            }

            return View(account);
        }

    }
}
