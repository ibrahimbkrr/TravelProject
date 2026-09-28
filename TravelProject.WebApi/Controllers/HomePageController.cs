using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelProject.Business.Abstract;
using TravelProject.Dto.HomePageDtos;
using TravelProject.Entity.Entities;

namespace TravelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly IHomePageService _homePageService;
        private readonly IMapper _mapper;

        public HomePageController(
            IHomePageService homePageService,
            IMapper mapper)
        {
            _homePageService = homePageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var homePages = await _homePageService.GetAllAsync();

            var result =
                _mapper.Map<List<ResultHomePageDto>>(homePages);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var homePage = await _homePageService.GetByIdAsync(id);

            if (homePage == null)
            {
                return NotFound();
            }

            var result =
                _mapper.Map<ResultHomePageDto>(homePage);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateHomePageDto createHomePageDto)
        {
            var homePage =
                _mapper.Map<HomePage>(createHomePageDto);

            await _homePageService.AddAsync(homePage);

            return Ok("Ana sayfa içeriği başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            UpdateHomePageDto updateHomePageDto)
        {
            var existingHomePage =
                await _homePageService.GetByIdAsync(
                    updateHomePageDto.HomePageId);

            if (existingHomePage == null)
            {
                return NotFound();
            }

            _mapper.Map(updateHomePageDto, existingHomePage);

            await _homePageService.UpdateAsync(existingHomePage);

            return Ok("Ana sayfa içeriği başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var homePage = await _homePageService.GetByIdAsync(id);

            if (homePage == null)
            {
                return NotFound();
            }

            await _homePageService.DeleteAsync(id);

            return Ok("Ana sayfa içeriği başarıyla silindi.");
        }
    }
}