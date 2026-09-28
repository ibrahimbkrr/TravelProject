using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelProject.Dto.AdminDtos;
using TravelProject.WebUI.ApiServices.Abstract;

namespace TravelProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminApiService _adminApiService;

        public LoginController(IAdminApiService adminApiService)
        {
            _adminApiService = adminApiService;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(string? returnUrl = null)
        {
            // Kullanıcı zaten giriş yaptıysa tekrar login sayfasını gösterme
            if (User.Identity != null &&
                User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(
            LoginAdminDto loginAdminDto,
            string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ReturnUrl = returnUrl;

                return View(loginAdminDto);
            }


            var admin =
                await _adminApiService.LoginAsync(loginAdminDto);


            if (admin == null)
            {
                ViewBag.Error =
                    "Kullanıcı adı veya şifre hatalı.";

                ViewBag.ReturnUrl = returnUrl;

                return View(loginAdminDto);
            }


            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    admin.AdminId.ToString()),

                new Claim(
                    ClaimTypes.Name,
                    admin.UserName),

                new Claim(
                    ClaimTypes.Role,
                    "Admin")
            };


            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);


            var principal =
                new ClaimsPrincipal(identity);


            var authenticationProperties =
                new AuthenticationProperties
                {
                    IsPersistent = false
                };


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                authenticationProperties);


            // Kullanıcı yetkisizken bir admin sayfasına gitmeye çalıştıysa
            // login sonrası o sayfaya geri gönder.
            if (!string.IsNullOrEmpty(returnUrl) &&
                Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }


            return RedirectToAction(
                "Index",
                "Admin");
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);


            return RedirectToAction(
                "Index",
                "Login");
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}