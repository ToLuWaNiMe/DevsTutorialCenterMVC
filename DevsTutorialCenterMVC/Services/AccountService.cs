using DevsTutorialCenterMVC.Models;
using System.Security.Claims;
using DevsTutorialCenterMVC.Services.Interfaces;

namespace DevsTutorialCenterMVC.Services;

public class AccountService : BaseService
{
    public AccountService(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(
        client, httpContextAccessor, config)
    {
    }
    
    public async Task<AccountDetailsViewModel> AccountsDetailsAsync(string id)
    {
        var viewModel = new AccountDetailsViewModel();

        return viewModel;
    }
}