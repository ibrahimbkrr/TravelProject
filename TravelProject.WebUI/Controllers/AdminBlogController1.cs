using Microsoft.AspNetCore.Mvc;
using TravelProject.Dto.BlogDtos;
using TravelProject.WebUI.ApiServices.Abstract;
using Microsoft.AspNetCore.Authorization;
namespace TravelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBlogController : Controller
    {

        private readonly IBlogApiService _blogApiService;

        public AdminBlogController(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogApiService.GetAllAsync();

            return View(blogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto createBlogDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createBlogDto);
            }

            createBlogDto.CreatedDate = DateTime.Now;

            await _blogApiService.CreateAsync(createBlogDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var blog = await _blogApiService.GetByIdAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            var updateBlogDto = new UpdateBlogDto
            {
                BlogId = blog.BlogId,
                Title = blog.Title,
                Description = blog.Description,
                ImageUrl = blog.ImageUrl,
                CreatedDate = blog.CreatedDate
            };

            return View(updateBlogDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogDto updateBlogDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateBlogDto);
            }

            await _blogApiService.UpdateAsync(updateBlogDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogApiService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}