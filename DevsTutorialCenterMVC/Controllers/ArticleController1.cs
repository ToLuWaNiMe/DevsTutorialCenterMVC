//using DevsTutorialCenterMVC.Models.Components;
//using DevsTutorialCenterMVC.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace DevsTutorialCenterMVC.Controllers
//{
//    public class ArticleController1 : Controller
//    {
//        private readonly IArticleService _articleService;

//        public ArticleController1(IArticleService articleService)
//        {
//            _articleService = articleService;
//        }


//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(ViewArticleVM article)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    bool result = await _articleService.Create(article);

//                    if (result)
//                    {
//                        return Json(new { success = true });
//                    }
//                    else
//                    {
//                        return Json(new { success = false, message = "Article creation failed. Please try again." });
//                    }
//                }

//                return Json(new { success = false, message = "Invalid model state." });
//            }
//            catch (Exception ex)
//            {
//                // Log the exception for further investigation
//                return Json(new { success = false, message = "An error occurred during article creation." });
//            }
//        }






//    }
//}
