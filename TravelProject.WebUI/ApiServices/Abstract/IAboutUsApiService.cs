using TravelProject.Dto.AboutUsDtos;

namespace TravelProject.WebUI.ApiServices.Abstract
{
    public interface IAboutUsApiService
    {
        Task<List<ResultAboutUsDto>> GetAllAsync();
        Task<ResultAboutUsDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateAboutUsDto createAboutUsDto);
        Task UpdateAsync(UpdateAboutUsDto updateAboutUsDto);
        Task DeleteAsync(int id);

    }
}
