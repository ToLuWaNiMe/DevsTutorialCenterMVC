using DevsTutorialCenterMVC.Data;
using DevsTutorialCenterMVC.Data.Entities;
using DevsTutorialCenterMVC.Data.Repositories;
using DevsTutorialCenterMVC.Services;
using DevsTutorialCenterMVC.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();


builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddTransient<IMessengerService, MessengerService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<BlogPostService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<TagService>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();