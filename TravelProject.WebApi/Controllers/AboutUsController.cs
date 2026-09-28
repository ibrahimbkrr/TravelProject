using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelProject.Business.Abstract;
using TravelProject.Dto.AboutUsDtos;
using TravelProject.Dto.BlogDtos;
using TravelProject.Entity.Entities;

namespace TravelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService _aboutUsService;
        private readonly IMapper _mapper;

        public AboutUsController(IAboutUsService aboutUsService, IMapper mapper)
        {
            _aboutUsService = aboutUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var aboutUs = await _aboutUsService.GetAllAboutUsAsync();

            var result = _mapper.Map<List<ResultAboutUsDto>>(aboutUs);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var aboutUS = await _aboutUsService.GetAboutUsByIdAsync(id);

            if (aboutUS == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<ResultAboutUsDto>(aboutUS);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutUsDto createAboutUsDto)
        { 
            var aboutUs = _mapper.Map<AboutUs>(createAboutUsDto);
            
            await _aboutUsService.AddAboutUsAsync(aboutUs);

            return Ok(aboutUs);


        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutUsDto updateAboutUsDto)
        {
            var existingAboutUs = await _aboutUsService.GetAboutUsByIdAsync(updateAboutUsDto.AboutUsId);

            if (existingAboutUs  == null)
            {
                return NotFound();
            }

            _mapper.Map(updateAboutUsDto, existingAboutUs);

            await _aboutUsService.UpdateAboutUsAsync(existingAboutUs);

            return Ok("AboutUs başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var aboutUs = await _aboutUsService.GetAboutUsByIdAsync(id);

            if (aboutUs == null)
            {
                return NotFound();
            }

            await _aboutUsService.DeleteAboutUsAsync(id);

            return Ok("AboutUs başarıyla silindi.");
        }


    }
}
