using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Services;
using DevsTutorialCenterMVC.Utilities;
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
        public async Task<IActionResult> Index(int? page, int? size)
        {
            int pageNum = page ?? 1;
            int pageSize = size ?? 3;

            var viewModelList = await _accountService.GetAllAccountsAsync();
            var paginatedViewModel = Helper.Paginate(viewModelList, pageNum, pageSize);

            return View(paginatedViewModel);
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

        public IActionResult AuthorsUnderAdmin()
        {
            return View();
        }
    }
}
