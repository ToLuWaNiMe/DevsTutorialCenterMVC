using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers
{
    [Route("dashboard")]
    public class DashboardController : Controller
    {
        private readonly LibraryPageService _libraryPageService;
        private readonly BlogPostService _blogPostService;
        private readonly AuthorService _authorService;
        private readonly StoryPageService _storyPageService;
        private readonly ArticleService _articleService;
        private readonly TagService _tagService;

        public DashboardController(LibraryPageService libraryPageService, BlogPostService blogPostService,
            AuthorService authorService, TagService tagService, StoryPageService storyPageService,
            ArticleService articleService)
        {
            _libraryPageService = libraryPageService;
            _blogPostService = blogPostService;
            _authorService = authorService;
            _tagService = tagService;
            _storyPageService = storyPageService;
            _articleService = articleService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                LatestBlogPosts = await _blogPostService.RecentPosts(),
                TrendingPosts = await _blogPostService.TrendingPosts(),
                PopularBlogPosts = await _blogPostService.PopularPosts(),
                Authors = (await _authorService.GetAllAuthorsAsync()).Take(3),
                Tags = await _tagService.AllTags(),
            };

            return View(model);
        }

        [HttpGet("settings")]
        [Authorize]
        public IActionResult Settings()
        {
            return View();
        }

        [HttpGet("story")]
        public async Task<IActionResult> StoryPage()
        {
            var pendingArticles = await _storyPageService.PendingArticlesAsync();
            var topAuthors = (await _authorService.GetAllAuthorsAsync()).Take(3);
            var allTags = await _tagService.AllTags();
            var recentBlogPost = _blogPostService.GetRecommendedArticles().Result.Take(3);

            var pageModel = new StoryPageVM
            {
                DraftArticles = pendingArticles.Take(2),
                PublishedArticles = pendingArticles.Take(4),
                PendingArticles = pendingArticles,
                TopAuthors = topAuthors,
                AllTags = allTags,
                RecentBlogPosts = recentBlogPost
            };

            return View(pageModel);
        }

        [HttpGet("library")]
        public async Task<IActionResult> LibraryPage()
        {
            var readArticles = await _libraryPageService.ReadArticles();
            var topAuthors = (await _authorService.GetAllAuthorsAsync()).Take(3);
            var allTags = await _tagService.AllTags();
            var recentBlogPost = _blogPostService.GetRecommendedArticles().Result.Take(3);
            var pageModel = new LibraryPageVM
            {
                ReadArticles = readArticles,
                TopAuthors = topAuthors,
                AllTags = allTags,
                RecentBlogPosts = recentBlogPost
            };

            return View(pageModel);
        }

        [HttpGet("article/create")]
        public async Task<IActionResult> CreateArticle()
        {
            var tags = await _tagService.AllTags();

            var createArticleDto = new CreateArticleDto
            {
                Tags = tags,
            };

            return View(createArticleDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleDto article)
        {
            var result = await _articleService.Create(article);

            if (!result)
                return BadRequest(new { success = false, message = "Article creation failed. Please try again." });
            
            return Ok(new { success = true, message = "Article created successfully." });

        }
    }
}