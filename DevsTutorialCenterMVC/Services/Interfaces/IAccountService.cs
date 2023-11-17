using System.Security.Claims;
using DevsTutorialCenterMVC.Models;

namespace DevsTutorialCenterMVC.Services.Interfaces;

public interface IAccountService
{
    Task<IEnumerable<GetAllAccountViewModel>> GetAllAccountsAsync();
    Task<AccountDetailsViewModel> AccountsDetailsAsync(string id);
    bool IsLoggedInAsync(ClaimsPrincipal user);
}