
using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services;
using DevsTutorialCenterMVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DevsTutorialCenterMVC.Controllers
{
    public class DashboardController : Controller
    {

        private readonly IArticleService _articleService;
        private readonly ITagService _tagService;

        private readonly LibraryPageService _libraryPageService;

        private readonly BlogPostService _blogPostService;
        private readonly StoryPageService _storyPageService;
        private readonly TagService _tagService;

        public DashboardController(BlogPostService blogPostService, IArticleService articleService, ITagService tagService)

     
        {
            

            _articleService = articleService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _blogPostService.LatestPosts();
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
            var topAuthors = await _libraryPageService.AllAuthors();
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

        public async Task<IActionResult> CreateArticle()
        {

            var tags = await _tagService.GetAllTagsAsync();

            var createArticleDto = new CreateArticleDto
            {

                TagId = tags?.ToList(),


            };

            return View(createArticleDto);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleDto article)
        {
            try
            {
                if (article == null)
                {
                    return BadRequest("Article data is missing.");
                }

                bool result = await _articleService.Create(article);

                if (result)
                {
                    return Ok(new { success = true, message = "Article created successfully." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Article creation failed. Please try again." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred during article creation." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateArticle(int articleId)
        {
            var article = await _articleService.GetArticleById(articleId);

            if (article == null)
            {
                return NotFound("Article not found.");
            }

            return View("UpdateArticle", article);
        }

        [HttpPatch("/api/articles/update-article/{articleId}")]
        public async Task<IActionResult> UpdateArticle(int articleId, [FromBody] JsonPatchDocument<UpdateArticleDto> patchDocument)
        {
            try
            {
                if (patchDocument == null)
                {
                    return BadRequest("Patch document is missing.");
                }

                var existingArticle = await _articleService.GetArticleById(articleId);

                if (existingArticle == null)
                {
                    return NotFound("Article not found.");
                }

                patchDocument.ApplyTo(existingArticle, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.AllErrors();
                    return BadRequest(new { success = false, errors });
                }

                bool result = await _articleService.UpdateArticle(articleId, existingArticle);

                if (result)
                {
                    return Ok(existingArticle);
                }
                else
                {
                    return BadRequest(new { success = false, message = "Article update failed. Please try again." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred during article update." });
            }
        }

        public async Task<IActionResult> LibraryPage()
        {
            var readArticles = await _libraryPageService.ReadArticles();
            var topAuthors = await _libraryPageService.AllAuthors();
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
