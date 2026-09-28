using System.Net.Http.Json;
using TravelProject.Dto.BlogDtos;
using TravelProject.WebUI.ApiServices.Abstract;

namespace TravelProject.WebUI.ApiServices.Concrete
{
    public class BlogApiService : IBlogApiService
    {
        private readonly HttpClient _httpClient;

        public BlogApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultBlogDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("api/Blogs");

            return response ?? new List<ResultBlogDto>();
        }

        public async Task<ResultBlogDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResultBlogDto>($"api/Blogs/{id}");
        }

        public async Task CreateAsync(CreateBlogDto createBlogDto)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Blogs",
                createBlogDto);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(UpdateBlogDto updateBlogDto)
        {
            var response = await _httpClient.PutAsJsonAsync(
                "api/Blogs",
                updateBlogDto);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Blogs/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}