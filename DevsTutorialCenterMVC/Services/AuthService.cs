using System.Security.Claims;
using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Models.Api.Responses;
using DevsTutorialCenterMVC.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DevsTutorialCenterMVC.Services;

public class AuthService : BaseService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(
        client, httpContextAccessor, config)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Result<LoginViewModel>> Login(LoginViewModel loginData)
    {
        const string url = "/api/auth/login";
        var response = await MakeRequest<ResponseObject<LoginResponseDto>, object>(url, "POST", new
        {
            Email = loginData.Email,
            Password = loginData.Password
        });

        if (!response.IsSuccessful)
            return Result.Failure<LoginViewModel>(response.Errors);

        var model = new LoginViewModel
        {
            Errors = response.Errors.Select(error => error.Message)
        };

        if (response.Errors.Any())
            return Result.Success(model);

        var token = response.Data.Token;
        var claims = new List<Claim>
        {
            new("Name", $"{response.Data.User.FirstName} {response.Data.User.LastName}"),
            new("Email", response.Data.User.Email),
            new ("ImageUrl", response.Data.User.ImageUrl),
            new("Stack", response.Data.User.Stack),
            new("Squad", response.Data.User.Squad),
            new("JwtToken", token),
        };

        var identity = new ClaimsIdentity(claims, "cookie");
        await _httpContextAccessor?.HttpContext?.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity))!;

        return Result.Success(loginData);
    }
    
    public async Task<Result> Register(SignUpViewModel signUpData)
    {
        const string url = "/api/auth/register";
        var response = await MakeRequest<ResponseObject<SignUpResponseDto>, object>(url, "POST", new
        {
            Email = signUpData.Email,
            FirstName = signUpData.FirstName,
            LastName = signUpData.LastName,
            Stack = signUpData.Stack,
            PhoneNumber = signUpData.PhoneNumber,
            Squad = signUpData.SquadNumber,
            Password = signUpData.Password,
            ConfirmPassword = signUpData.ConfirmPassword
        });

        if (!response.IsSuccessful)
            return Result.Failure(response.Errors);

        return Result.Success();
    }
}