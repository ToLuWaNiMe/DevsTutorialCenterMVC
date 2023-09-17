using DevsTutorialCenterMVC.Data.Entities;
using DevsTutorialCenterMVC.Data.Repositories;
using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsTutorialCenterMVC.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository _repository;

        public AccountService(IRepository repository)
        {
            _repository = repository;
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
