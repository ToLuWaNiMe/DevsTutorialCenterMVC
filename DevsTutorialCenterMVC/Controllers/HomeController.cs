using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevsTutorialCenterMVC.Models;
using Microsoft.AspNetCore.Authorization;
using DevsTutorialCenterMVC.Data.Entities;
using DevsTutorialCenterMVC.Data.Repositories;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Identity;

namespace DevsTutorialCenterMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMessengerService _messengerService;
    private readonly IRepository _repository;

    public HomeController(
        ILogger<HomeController> logger,
        UserManager<AppUser> userManager,
        IMessengerService messengerService,
        IRepository repository)
    {
        _logger = logger;
        _userManager = userManager;
        _messengerService = messengerService;
        _repository = repository;
    }

    public IActionResult Index()
    {
        return View();
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

    [Authorize]
    public IActionResult BlogPost()
    {
        return View();
    }

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
