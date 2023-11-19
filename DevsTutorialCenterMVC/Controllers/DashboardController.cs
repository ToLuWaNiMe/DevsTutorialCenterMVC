using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DevsTutorialCenterMVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DashboardService _dashboardService;
        private readonly BlogPostService _blogPostService;
        private readonly TagService _tagService;

        public DashboardController(DashboardService dashboardService, BlogPostService blogPostService, TagService tagService)
        {
            _dashboardService = dashboardService;
            _blogPostService = blogPostService;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            var articles =  _blogPostService.LatestPosts();
            
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

        public async Task<IActionResult> LibraryPage()
        {
            var readArticles = await _dashboardService.ReadArticles();
            var topAuthors = await _dashboardService.AllAuthors();
            var allTags = await _tagService.AllTags();

            var pageModel = new LibraryPageVM
            {
                ReadArticles = readArticles,
                TopAuthors = topAuthors,
                AllTags = allTags
            };
            //    AllTags = new List<TagComponentViewModel>
            //    {
            //        new()
            //        {
            //            Id = "",
            //            Name = "JAVA"
            //        },
            //        new()
            //        {
            //            Id = "",
            //            Name = "DOTNET"
            //        }
            //    },

            //    ReadArticles = new List<BlogPostListItemVM>
            //    {
            //        new()
            //        {
            //            Author = new AuthorListItemViewModel{Name = "Ayomide", Designation = "UI UX Designer", Image = "", NumberOfArticles = 53},
            //            CreatedOn = "23 May 2023",
            //            Id = "",
            //            ImageUrl = "",
            //            ReadTime = "5 mins",
            //            Tag = new TagComponentViewModel{Name = "JAVA", Id =""},
            //            Text = "The era of technological inventions with JAVA Stack",
            //            Title = "Mastering Java",

            //        },
            //         new()
            //         {
            //            Author = new AuthorListItemViewModel{Name = "Ayomide", Designation = "UI UX Designer", Image = "", NumberOfArticles = 53},
            //            CreatedOn = "23 May 2023",
            //            Id = "",
            //            ImageUrl = "",
            //            ReadTime = "5 mins",
            //            Tag = new TagComponentViewModel{Name = "JAVA", Id =""},
            //            Text = "The era of technological inventions with JAVA Stack",
            //            Title = "Mastering Java",

            //         },
            //          new()
            //          {
            //            Author = new AuthorListItemViewModel{Name = "Ayomide", Designation = "UI UX Designer", Image = "", NumberOfArticles = 53},
            //            CreatedOn = "23 May 2023",
            //            Id = "",
            //            ImageUrl = "",
            //            ReadTime = "5 mins",
            //            Tag = new TagComponentViewModel{Name = "JAVA", Id =""},
            //            Text = "The era of technological inventions with JAVA Stack",
            //            Title = "Mastering Java",

            //          }
            //    },

            //    TopAuthors = new List<AuthorListItemViewModel>
            //    {
            //        new()
            //        {
            //            Name = "Ayomide",
            //            Designation = "UI UX Designer",
            //            Image = "",
            //            NumberOfArticles = 56,
            //        },
            //        new()
            //        {
            //            Name = "Ayomide",
            //            Designation = "UI UX Designer",
            //            Image = "",
            //            NumberOfArticles = 56,
            //        },
            //        new()
            //        {
            //            Name = "Ayomide",
            //            Designation = "UI UX Designer",
            //            Image = "",
            //            NumberOfArticles = 56,
            //        }
            //    }
            //};
            return View(pageModel);
        }
    }
}
