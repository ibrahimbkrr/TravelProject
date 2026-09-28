using System.Net.Http.Json;
using TravelProject.Dto.CommentDtos;
using TravelProject.WebUI.ApiServices.Abstract;

namespace TravelProject.WebUI.ApiServices.Concrete
{
    public class CommentApiService : ICommentApiService
    {
        private readonly HttpClient _httpClient;

        public CommentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCommentDto>> GetAllAsync()
        {
            var comments =
                await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>(
                    "api/Comment");

            return comments ?? new List<ResultCommentDto>();
        }

        public async Task CreateAsync(CreateCommentDto createCommentDto)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Comment",
                createCommentDto);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Comment/{id}");
        }
    }
}