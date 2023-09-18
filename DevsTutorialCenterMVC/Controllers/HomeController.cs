using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevsTutorialCenterMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace DevsTutorialCenterMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult OpenArticle()
    {
        return View();
    }
    
    [Authorize]    
    public IActionResult Privacy()
    {
        return View();
    }

    [Authorize]
    public IActionResult BlogPost()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

