using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelProject.WebUI.ApiServices.Abstract;
using TravelProject.WebUI.Models;

namespace TravelProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogApiService _blogApiService;

        public HomeController(
            ILogger<HomeController> logger,
            IBlogApiService blogApiService)
        {
            _logger = logger;
            _blogApiService = blogApiService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogApiService.GetAllAsync();

            return View(blogs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                            ?? HttpContext.TraceIdentifier
            });
        }
    }
}