using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Data.Entities;
using DevsTutorialCenterMVC.Data.Repositories;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Identity;
using DevsTutorialCenterMVC.Data.MethodExtensions;

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
    public IActionResult OpenArticle()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult BlogPost()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    //[Authorize]
    public PartialViewResult SendDecadevInvite()
    {
        return PartialView("_SendDecadevInvitePartial");
    }

    [HttpPost]
    //[Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SendDecadevInvite([FromBody] DecadevInviteViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.AllErrors();
            return BadRequest(new ResObj{ Code = 400, Error = errors });
            
        }

        //var user = await _userManager.GetUserAsync(User);

        // this user is for initial testing
        var user = await _repository.GetByIdAsync<AppUser>("148d2f6f-af7a-423a-baa2-f01d434d9b3a");

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
            // Display a success message modal and return the response

            return Ok(new { Code = 200, Error = new List<string>() });
        }
        
        ModelState.AddModelError("email", "Failure sending message");
        var allErrors = ModelState.AllErrors();
        return BadRequest(new ResObj { Code = 400, Error = allErrors });
    }

    
}
