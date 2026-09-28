using System.Net.Http.Json;
using TravelProject.Dto.AdminDtos;
using TravelProject.WebUI.ApiServices.Abstract;

namespace TravelProject.WebUI.ApiServices.Concrete
{
    public class AdminApiService : IAdminApiService
    {
        private readonly HttpClient _httpClient;

        public AdminApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultAdminDto?> LoginAsync(
            LoginAdminDto loginAdminDto)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Admin/Login",
                loginAdminDto);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content
                .ReadFromJsonAsync<ResultAdminDto>();
        }
    }
}