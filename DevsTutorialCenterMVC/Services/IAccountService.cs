using System.Security.Claims;

namespace DevsTutorialCenterMVC.Services
{
    public interface IAccountService
    {
        bool IsLoggedInAsync(ClaimsPrincipal user);
    }
}
