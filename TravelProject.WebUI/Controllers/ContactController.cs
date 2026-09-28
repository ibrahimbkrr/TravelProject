using Microsoft.AspNetCore.Mvc;
using TravelProject.Dto.ContactDtos;
using TravelProject.WebUI.ApiServices.Abstract;

namespace TravelProject.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactApiService _contactApiService;

        public ContactController(IContactApiService contactApiService)
        {
            _contactApiService = contactApiService;
        }

        [HttpGet]
        public IActionResult Index(bool success = false)
        {
            ViewBag.Success = success;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createContactDto);
            }

            createContactDto.CreatedDate = DateTime.Now;

            await _contactApiService.CreateAsync(createContactDto);

            return RedirectToAction("Index", new { success = true });
        }
    }
}