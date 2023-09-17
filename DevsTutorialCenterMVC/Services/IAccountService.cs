using DevsTutorialCenterMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevsTutorialCenterMVC.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<GetAllAccountViewModel>> GetAllAccountsAsync();
        Task<AccountDetailsViewModel> AccountsDetailsAsync(string id);
    }
}
