using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DevsTutorialCenterMVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DashboardService _dashboardService;
        private readonly BlogPostService _blogPostService;
        private readonly StoryPageService _storyPageService;
        private readonly TagService _tagService;

        public DashboardController(DashboardService dashboardService, BlogPostService blogPostService, TagService tagService, StoryPageService storyPageService)
        {
            _dashboardService = dashboardService;
            _blogPostService = blogPostService;
            _tagService = tagService;
            _storyPageService = storyPageService;
        }

        public IActionResult Index()
        {
            var articles =  _blogPostService.LatestPosts();
            
            return View(articles);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Settings()
        {
            return View();
        }

        public async Task<IActionResult> StoryPage()
        {
            var pendingArticles = await _storyPageService.PendingArticlesAsync();
            var topAuthors = await _dashboardService.AllAuthors();
            var allTags = await _tagService.AllTags();
            var recentBlogPost =  _blogPostService.GetRecommendedArticles().Result.Take(3);

            var pageModel = new StoryPageVM
            {
                PendingArticles = pendingArticles,
                TopAuthors = topAuthors,
                AllTags = allTags,
                RecentBlogPosts = recentBlogPost
            };

            return View(pageModel);
        }


        public IActionResult CreateArticle()
        {
            return View();
        }

        public async Task<IActionResult> LibraryPage()
        {
            var readArticles = await _dashboardService.ReadArticles();
            var topAuthors = await _dashboardService.AllAuthors();
            var allTags = await _tagService.AllTags();
            var recentBlogPost =  _blogPostService.GetRecommendedArticles().Result.Take(3);
            var pageModel = new LibraryPageVM
            {
                ReadArticles = readArticles,
                TopAuthors = topAuthors,
                AllTags = allTags,
                RecentBlogPosts = recentBlogPost
            };

            return View(pageModel);
        }
    }
}
