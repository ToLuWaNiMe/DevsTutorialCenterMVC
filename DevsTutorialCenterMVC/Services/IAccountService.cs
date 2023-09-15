using DevsTutorialCenterMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevsTutorialCenterMVC.Services
{
    public interface IAccountService
    {
      Task<PaginatorResponseViewModel<IEnumerable<GetAllAccountViewModel>>> GetAllAccountsAsync(AccountDetailsViewModel account);
        Task<AccountDetailsViewModel> AccountsDetailsAsync(string id);
    }
}
