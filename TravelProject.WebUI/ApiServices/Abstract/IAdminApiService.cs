using TravelProject.Dto.AdminDtos;

namespace TravelProject.WebUI.ApiServices.Abstract
{
    public interface IAdminApiService
    {
        Task<ResultAdminDto?> LoginAsync(LoginAdminDto loginAdminDto);
    }
}