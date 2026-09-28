using Microsoft.AspNetCore.Authentication.Cookies;
using TravelProject.WebUI.ApiServices.Abstract;
using TravelProject.WebUI.ApiServices.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var apiBaseUrl = "https://travelproject-api-ibrahim-feajdmaceqhyf0gs.westus3-01.azurewebsites.net/";


// BLOG
builder.Services.AddHttpClient<IBlogApiService, BlogApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});


// ABOUT
builder.Services.AddHttpClient<IAboutUsApiService, AboutUsApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});


// CONTACT
builder.Services.AddHttpClient<IContactApiService, ContactApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});


// COMMENT
builder.Services.AddHttpClient<ICommentApiService, CommentApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});


// ADMIN LOGIN
builder.Services.AddHttpClient<IAdminApiService, AdminApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});


// COOKIE AUTHENTICATION
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.LogoutPath = "/Login/Logout";
        options.AccessDeniedPath = "/Login/AccessDenied";

        options.ExpireTimeSpan = TimeSpan.FromHours(2);
        options.SlidingExpiration = true;
    });


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


// ÖNCE Authentication
app.UseAuthentication();

// SONRA Authorization
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();