using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelProject.Business.Abstract;
using TravelProject.Dto.BlogDtos;
using TravelProject.Entity.Entities;

namespace TravelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
      private readonly IBlogService _blogService;
      private readonly IMapper _mapper;

        public BlogsController ( IBlogService blogService, IMapper mapper )
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            var blogs = await _blogService.GetAllAsync();

            var result = _mapper.Map<List<ResultBlogDto>>(blogs);
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blogs = await _blogService.GetByIdAsync(id);

            if (blogs == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<ResultBlogDto>(blogs);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create (CreateBlogDto createBlogDto)
        {
           var blog = _mapper.Map<Blog>(createBlogDto);

            await _blogService.AddAsync(blog);

            return Ok("BLOG BAŞARIYLA EKLENDİ");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogDto updateBlogDto)
        {
            var existingBlog = await _blogService.GetByIdAsync(updateBlogDto.BlogId);

            if (existingBlog == null)
            {
                return NotFound();
            }

            _mapper.Map(updateBlogDto, existingBlog);

            await _blogService.UpdateAsync(existingBlog);

            return Ok("Blog başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            await _blogService.DeleteAsync(id);

            return Ok("Blog başarıyla silindi.");
        }


    }
}