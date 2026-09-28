using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelProject.Business.Abstract;
using TravelProject.Dto.CommentDtos;
using TravelProject.Entity.Entities;

namespace TravelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(
            ICommentService commentService,
            IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentService.GetAllWithBlogAsync();

            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentService.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<ResultCommentDto>(comment);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateCommentDto createCommentDto)
        {
            var comment = _mapper.Map<Comment>(createCommentDto);

            await _commentService.AddAsync(comment);

            return Ok("Yorum başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            UpdateCommentDto updateCommentDto)
        {
            var existingComment =
                await _commentService.GetByIdAsync(
                    updateCommentDto.CommentId);

            if (existingComment == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCommentDto, existingComment);

            await _commentService.UpdateAsync(existingComment);

            return Ok("Yorum başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _commentService.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            await _commentService.DeleteAsync(id);

            return Ok("Yorum başarıyla silindi.");
        }
    }
}