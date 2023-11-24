using DevsTutorialCenterMVC.Services;
using DevsTutorialCenterMVC.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<DevsTutorialCenterMVCContext>(
    option => option.UseNpgsql(builder.Configuration.GetConnectionString("ProdDb"))
);
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
=======
builder.Services.AddHttpClient();


builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddTransient<IMessengerService, MessengerService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<BlogPostService>();
builder.Services.AddScoped<IArticleService, ArticleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
>>>>>>> Stashed changes
{
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<DevsTutorialCenterMVCContext>()
  .AddDefaultTokenProviders();

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddTransient<IMessengerService, MessengerService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IReportedArticleAdminService, ReportedArticleAdminService>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DashBoard}/{action=CreateArticle}/{id?}");


app.Run();