using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BlogPostService _blogPostService;

        public DashboardController(BlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
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

        public IActionResult DraftArticles()
        {
            return View();
        }


        public IActionResult CreateArticle()
        {
            return View();
        }
    }
}
