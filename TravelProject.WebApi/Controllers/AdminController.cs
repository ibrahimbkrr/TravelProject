using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelProject.Business.Abstract;
using TravelProject.Dto.AdminDtos;

namespace TravelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(
            IAdminService adminService,
            IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginAdminDto loginAdminDto)
        {
            var admin = await _adminService.LoginAsync(
                loginAdminDto.UserName,
                loginAdminDto.Password);

            if (admin == null)
            {
                return Unauthorized("Kullanıcı adı veya şifre hatalı.");
            }

            var result = _mapper.Map<ResultAdminDto>(admin);

            return Ok(result);
        }
    }
}