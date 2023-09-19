using DevsTutorialCenterMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;

namespace DevsTutorialCenterMVC.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<GetAllAccountViewModel>> GetAllAccountsAsync();
        Task<AccountDetailsViewModel> AccountsDetailsAsync(string id);
        bool IsLoggedInAsync(ClaimsPrincipal user);
    }
}
