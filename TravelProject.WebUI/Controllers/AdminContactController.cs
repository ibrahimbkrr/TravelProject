using Microsoft.AspNetCore.Mvc;
using TravelProject.WebUI.ApiServices.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace TravelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminContactController : Controller
    {
        private readonly IContactApiService _contactApiService;

        public AdminContactController(IContactApiService contactApiService)
        {
            _contactApiService = contactApiService;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _contactApiService.GetAllAsync();

            return View(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var contact = await _contactApiService.GetByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }
    }
}