using Microsoft.AspNetCore.Mvc;
using TravelProject.WebUI.ApiServices.Abstract;

namespace TravelProject.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutUsApiService _aboutUsApiService;

        public AboutController(IAboutUsApiService aboutUsApiService)
        {
            _aboutUsApiService = aboutUsApiService;
        }

        public async Task<IActionResult> Index()
        {
            var aboutUsList = await _aboutUsApiService.GetAllAsync();

            var aboutUs = aboutUsList.FirstOrDefault();

            return View(aboutUs);
        }
    }
}