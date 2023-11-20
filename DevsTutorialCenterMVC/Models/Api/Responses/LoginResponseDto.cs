namespace DevsTutorialCenterMVC.Models.Api.Responses;

public class LoginResponseDto
{
    public AppUserDto User { get; set; }
    public string Token { get; set; }
    public IEnumerable<Error> Errors { get; set; }
}

public class AppUserDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    public string Stack { get; set; }

    public string Squad { get; set; }

    public string ImageUrl { get; set; }
}