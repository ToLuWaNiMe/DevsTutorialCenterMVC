namespace DevsTutorialCenterMVC.Extensions;

public static class AuthenticationConfiguration
{
    public static void AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration config,
        IHostEnvironment env)
    {
        services.AddAuthentication()
            .AddCookie("cookie");
        
    }
}