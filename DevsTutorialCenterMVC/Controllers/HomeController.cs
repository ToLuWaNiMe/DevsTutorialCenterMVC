using Microsoft.AspNetCore.Mvc;
using DevsTutorialCenterMVC.Models;
using Microsoft.AspNetCore.Authorization;
using DevsTutorialCenterMVC.Data.Entities;
using DevsTutorialCenterMVC.Data.Repositories;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Identity;
using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Services.Interfaces;

namespace DevsTutorialCenterMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMessengerService _messengerService;
    private readonly IRepository _repository;
    private readonly IAccountService _accountService;
    
    private readonly BlogPostService _blogPostService;

    public HomeController(BlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    public async Task<IActionResult> Index()
    {
        // var articles = (await _blogPostService.GetAllArticles()).PageItems.ToArray()[..3];

        var articles = await _blogPostService.LatestPosts();
        return View(articles);
    }

    [Authorize]
    public IActionResult OpenArticle()
    {
        return View();
    }
      
    public IActionResult Privacy()
    {
        return View();
    }

    // [Authorize]
    // public async Task<IActionResult> BlogPost()
    // {
    //
    //     
    //
    //     var latestPostResult = await _blogPostService.LatestPosts();
    //     var trendingResult = await _blogPostService.TrendingPosts();
    //     var popularResult = await _blogPostService.Popular();
    //     var interestingTopicsResult = await _blogPostService.InterestingTopics();
    //
    //     var allAuthors = await _accountService.GetAllAccountsAsync();
    //     var topThreeAuthors = Helper.Paginate(allAuthors, 1, 3);
    //
    //     if (latestPostResult == null)
    //     {
    //         
    //         return NotFound("Article not found.");
    //     }
    //     var pageModel = new BlogPostViewModel
    //     {
    //         GetAllArticlesViewModels = latestPostResult,
    //        TrendingPostsViewModels = trendingResult,
    //        PopularViewModels = popularResult,
    //        InterestingTopicsViewModels = interestingTopicsResult,
    //         GetAllAuthors = topThreeAuthors
    //     };
    //
    //     return View(pageModel);
    //     
    // }



  



    [HttpGet]
    [Authorize]
    public IActionResult SendDecadevInvite()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SendDecadevInvite(DecadevInviteViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userManager.GetUserAsync(User);

        var inviteToken = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultEmailProvider, "Invite Decadev");

        var UseInviteLink = Url.Action("SignUp", "Account",
            new
            {
                Firstname = model.FirstName,
                Lastname = model.LastName,
                email = model.Email,
                Userstack = model.Stack,
                Squadnumber = model.SquadNumber,
                token = inviteToken
            },
            Request.Scheme);

        var body = MessageBody.Content(UseInviteLink);

        var emailList = new List<string>{ model.Email };

        Message message = new("Decadev Community Invitation", emailList, body);

        if (_messengerService.Send(message) == "")
        {
            TempData["isSent"] = "Email was sent successfully";
            return RedirectToAction("BlogPost", "Home");
        }

        TempData["isSent"] = "Failed";
        return RedirectToAction("BlogPost", "Home");
    }

    
}
