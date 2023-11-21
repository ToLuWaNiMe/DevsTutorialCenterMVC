using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers;

public class AdminController : Controller
{
    public async Task<IActionResult> Index(int? page, int? size)
    {
        return View();
    }
        
    public async Task<IActionResult> AccountDetails(string id)
    {
        return View();
    }

    public IActionResult AuthorsUnderAdmin()
    {
        return View();
    }
}