using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace DevsTutorialCenterMVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BlogPostService _blogPostService;
        private readonly StoryPageService _storyPageService;

        public DashboardController(BlogPostService blogPostService, StoryPageService storyPageService)
        {
            _blogPostService = blogPostService;
            _storyPageService = storyPageService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _blogPostService.LatestPosts();
            
            return View(articles);
        }

        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }

        public async Task<IActionResult> StoryPage()
        {
            var pendingArticles = await _storyPageService.PendingArticlesAsync();

            var pageModel = new StoryPageVM
            {
                PendingArticles = pendingArticles,
            };

            return View(pageModel);
        }


        public IActionResult CreateArticle()
        {
            return View();
        }
    }
}
