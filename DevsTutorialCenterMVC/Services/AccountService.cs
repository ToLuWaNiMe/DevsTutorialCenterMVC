using DevsTutorialCenterMVC.Data.Entities;
using DevsTutorialCenterMVC.Data.Repositories;
using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DevsTutorialCenterMVC.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository _repository;
        
        public AccountService(HttpClient client, IConfiguration config) : base(client, config)
        {
        }

        // public AccountService(HttpClient client, IConfiguration config,
        //     SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IRepository repository)
        //     :base(client, config)
        // {
        //     _signInManager = signInManager;
        //     _userManager = userManager;
        //     _repository = repository;
        // }

        public bool IsLoggedInAsync(ClaimsPrincipal user)
        {
            if (_signInManager.IsSignedIn(user))
                return true;
            return false;
        }

        public async Task<IEnumerable<GetAllAccountViewModel>> GetAllAccountsAsync()
        {
            var appUsers = await _repository.GetAllAsync<AppUser>();
            var viewModelList = appUsers.Select(appUser => new GetAllAccountViewModel
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Email = appUser.Email,
                ImageUrl = appUser.ImageUrl

            }).ToList();

            return viewModelList;
        }

        public async Task<AccountDetailsViewModel> AccountsDetailsAsync(string id)
        {
            var appUser = await _repository.GetByIdAsync<AppUser>(id);


            {
                var viewModel = new AccountDetailsViewModel
                {

                    Id = appUser.Id,
                    FirstName = appUser.FirstName,
                    LastName = appUser.LastName,
                    Email = appUser.Email,
                    IsReported = appUser.IsReported,
                    PublicId = appUser.PublicId,
                    ImageUrl = appUser.ImageUrl,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                return viewModel;
            }
        }


    }
}
