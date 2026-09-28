using Microsoft.AspNetCore.Mvc;
using TravelProject.WebUI.ApiServices.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace TravelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCommentController : Controller
    {
        private readonly ICommentApiService _commentApiService;

        public AdminCommentController(ICommentApiService commentApiService)
        {
            _commentApiService = commentApiService;
        }

        public async Task<IActionResult> Index()
        {
            var comments = await _commentApiService.GetAllAsync();

            return View(comments);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentApiService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}