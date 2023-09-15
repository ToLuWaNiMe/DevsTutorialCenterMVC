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

        public async Task<PaginatorResponseViewModel<IEnumerable<GetAllAccountViewModel>>> GetAllAccountsAsync(AccountDetailsViewModel account)
        {
            var appUsers = await _repository.GetAllAsync<AppUser>();
            var viewModelList = new List<GetAllAccountViewModel>();

            foreach (var appUser in appUsers)
            {
                var viewModel = new GetAllAccountViewModel
                {
                    Id = appUser.Id,
                    FirstName = appUser.FirstName,
                    LastName = appUser.LastName,
                    Email = appUser.Email,
                    ImageUrl = appUser.ImageUrl
                   
                };

                viewModelList.Add(viewModel);
            }

            int pageNum = account.Page ?? 1;
            int pageSize = account.Size ?? 3;
            var skipAmount = (pageNum - 1) * pageSize;

            var paginatorResponse = Helper.Paginate(viewModelList, pageNum, pageSize);
            return paginatorResponse;
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
