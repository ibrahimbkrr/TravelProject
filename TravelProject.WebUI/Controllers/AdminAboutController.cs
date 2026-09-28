using Microsoft.AspNetCore.Mvc;
using TravelProject.Dto.AboutUsDtos;
using TravelProject.WebUI.ApiServices.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace TravelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminAboutController : Controller
    {
        private readonly IAboutUsApiService _aboutUsApiService;

        public AdminAboutController(IAboutUsApiService aboutUsApiService)
        {
            _aboutUsApiService = aboutUsApiService;
        }

        public async Task<IActionResult> Index()
        {
            var aboutList = await _aboutUsApiService.GetAllAsync();

            return View(aboutList);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var about = await _aboutUsApiService.GetByIdAsync(id);

            if (about == null)
            {
                return NotFound();
            }

            var updateAboutUsDto = new UpdateAboutUsDto
            {
                AboutUsId = about.AboutUsId,
                Title = about.Title,
                Description = about.Description,
                ImageUrl = about.ImageUrl
            };

            return View(updateAboutUsDto);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutUsDto updateAboutUsDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateAboutUsDto);
            }

            await _aboutUsApiService.UpdateAsync(updateAboutUsDto);

            return RedirectToAction("Index");
        }
    }
}