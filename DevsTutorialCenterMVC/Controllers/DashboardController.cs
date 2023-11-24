using DevsTutorialCenterMVC.Extensions;
using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Services;
using DevsTutorialCenterMVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ITagService _tagService;
        private readonly BlogPostService _blogPostService;

        public DashboardController(BlogPostService blogPostService, IArticleService articleService, ITagService tagService)
        {
            _blogPostService = blogPostService;
            _articleService = articleService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _blogPostService.LatestPosts();

            return View(articles);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult DraftArticles()
        {
            return View();
        }



        public async Task<IActionResult> CreateArticle()

        {
            var model = new GetAllTagsDto();

            try
            {
                var tags = await _tagService.GetAllTagsAsync();


                model.TagId = tags;

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Home");
            }
        }





        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleDto article)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await _articleService.Create(article);


                }

                return View();
            }
            catch (Exception ex)
            {

                return RedirectToAction("Home");
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




    }
}
