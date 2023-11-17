using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers
{
    public class ArticleController1 : Controller
    {
        private readonly IArticleService _articleService;
        public ArticleController1(IArticleService articleService)
        {
            _articleService = articleService;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(ViewArticleVM article)
        {
            if (ModelState.IsValid)
            {

                bool result = await _articleService.Create(article);

                if (result)
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Article creation failed. Please try again.");
                }
            }


            return View(article);
        }




    }
}
