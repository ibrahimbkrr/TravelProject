using Microsoft.AspNetCore.Mvc;
using TravelProject.WebUI.ApiServices.Abstract;
using TravelProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace TravelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IBlogApiService _blogApiService;
        private readonly ICommentApiService _commentApiService;
        private readonly IContactApiService _contactApiService;

        public AdminController(
            IBlogApiService blogApiService,
            ICommentApiService commentApiService,
            IContactApiService contactApiService)
        {
            _blogApiService = blogApiService;
            _commentApiService = commentApiService;
            _contactApiService = contactApiService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogApiService.GetAllAsync();
            var comments = await _commentApiService.GetAllAsync();
            var contacts = await _contactApiService.GetAllAsync();

            var model = new AdminDashboardViewModel
            {
                BlogCount = blogs.Count,
                CommentCount = comments.Count,
                ContactCount = contacts.Count
            };

            return View(model);
        }
    }
}