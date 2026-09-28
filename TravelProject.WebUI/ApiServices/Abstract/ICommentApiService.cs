using TravelProject.Dto.CommentDtos;

namespace TravelProject.WebUI.ApiServices.Abstract
{
    public interface ICommentApiService
    {
        Task<List<ResultCommentDto>> GetAllAsync();
        Task CreateAsync(CreateCommentDto createCommentDto);

        Task DeleteAsync(int id);
    }
}