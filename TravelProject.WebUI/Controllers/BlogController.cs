using Microsoft.AspNetCore.Mvc;
using TravelProject.Dto.CommentDtos;
using TravelProject.WebUI.ApiServices.Abstract;
using TravelProject.WebUI.Models;

namespace TravelProject.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogApiService _blogApiService;
        private readonly ICommentApiService _commentApiService;

        public BlogController(
            IBlogApiService blogApiService,
            ICommentApiService commentApiService)
        {
            _blogApiService = blogApiService;
            _commentApiService = commentApiService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogApiService.GetAllAsync();

            return View(blogs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var blog = await _blogApiService.GetByIdAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            var comments = await _commentApiService.GetAllAsync();

            var blogComments = comments
                .Where(x => x.BlogId == id)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();

            var blogs = await _blogApiService.GetAllAsync();

            var recentBlogs = blogs
                .Where(x => x.BlogId != id)
                .OrderByDescending(x => x.CreatedDate)
                .Take(5)
                .ToList();

            var model = new BlogDetailViewModel
            {
                Blog = blog,
                Comments = blogComments,
                NewComment = new CreateCommentDto(),
                RecentBlogs = recentBlogs
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(BlogDetailViewModel model)
        {
            model.NewComment.BlogId = model.Blog.BlogId;
            model.NewComment.CreatedDate = DateTime.Now;

            await _commentApiService.CreateAsync(model.NewComment);

            return RedirectToAction(
                "Detail",
                new { id = model.Blog.BlogId });
        }
    }
}