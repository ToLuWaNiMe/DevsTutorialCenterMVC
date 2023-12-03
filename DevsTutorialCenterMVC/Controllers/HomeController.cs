using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers;

public class HomeController : Controller
{
    private readonly BlogPostService _blogPostService;

    public HomeController(BlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    public async Task<IActionResult> Index()
    {
        var articles = await _blogPostService.LatestPosts();
        return View(articles);
    } 

    [Authorize]
    public IActionResult OpenArticle()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    [Authorize]
    public IActionResult SendDecadevInvite()
    {
        return View();
    }
}
