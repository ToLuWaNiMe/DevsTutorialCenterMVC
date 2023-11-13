using DevsTutorialCenterMVC.Data;
using DevsTutorialCenterMVC.Data.Entities;
using DevsTutorialCenterMVC.Data.Repositories;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
// builder.Services.AddDbContext<DevsTutorialCenterMVCContext>(
//     option => option.UseNpgsql(builder.Configuration.GetConnectionString("ProdDb"))
// );
// builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
// {
//     options.SignIn.RequireConfirmedEmail = true;
// }).AddEntityFrameworkStores<DevsTutorialCenterMVCContext>()
//   .AddDefaultTokenProviders();

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddTransient<IMessengerService, MessengerService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Seeder.SeedeMe(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();