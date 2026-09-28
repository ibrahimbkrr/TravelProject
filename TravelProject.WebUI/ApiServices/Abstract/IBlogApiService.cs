using TravelProject.Dto.BlogDtos;

namespace TravelProject.WebUI.ApiServices.Abstract
{
    public interface IBlogApiService
    {
        Task<List<ResultBlogDto>> GetAllAsync();
        Task<ResultBlogDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateBlogDto createBlogDto);
        Task UpdateAsync(UpdateBlogDto updateBlogDto);
        Task DeleteAsync(int id);
    }
}