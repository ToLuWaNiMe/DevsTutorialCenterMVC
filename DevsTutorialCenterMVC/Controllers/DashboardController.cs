using DevsTutorialCenterMVC.Data.MethodExtensions;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services;
using DevsTutorialCenterMVC.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly BlogPostService _blogPostService;

        public DashboardController(BlogPostService blogPostService, IArticleService articleService)
        {
            _blogPostService = blogPostService;
            _articleService = articleService;
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




        [HttpPost]
        public async Task<IActionResult> CreateArticle(ViewArticleVM article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await _articleService.Create(article);

                    if (result)
                    {
                        return Json(new { success = true });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Article creation failed. Please try again." });
                    }
                }

                return Json(new { success = false, message = "Invalid model state." });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = "An error occurred during article creation." });
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
        public async Task<IActionResult> UpdateArticle(int articleId, [FromBody] JsonPatchDocument<ViewArticleVM> patchDocument)
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




    }
}
