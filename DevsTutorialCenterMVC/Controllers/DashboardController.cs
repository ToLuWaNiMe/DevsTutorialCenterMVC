﻿using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        public IActionResult PublishedArticles()
        {
            return View();
        }

        public IActionResult PendingArticles()
        {
            return View();
        }
    }
}
