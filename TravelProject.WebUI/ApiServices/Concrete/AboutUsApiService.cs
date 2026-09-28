using TravelProject.Dto.AboutUsDtos;
using TravelProject.WebUI.ApiServices.Abstract;

namespace TravelProject.WebUI.ApiServices.Concrete
{
    public class AboutUsApiService : IAboutUsApiService
    {

        private readonly HttpClient _httpClient;

        public AboutUsApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task CreateAsync(CreateAboutUsDto createAboutUsDto)
        {
            var response =  await _httpClient.PostAsJsonAsync("api/AboutUs", createAboutUsDto);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
           var response =  await _httpClient.DeleteAsync($"api/AboutUs/{id}");
            response.EnsureSuccessStatusCode();
           
        }

        public async Task<List<ResultAboutUsDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultAboutUsDto>>("api/AboutUs");

            return response ?? new List<ResultAboutUsDto>();
        }

        public async Task<ResultAboutUsDto?> GetByIdAsync(int id)
        {
           return await _httpClient.GetFromJsonAsync<ResultAboutUsDto>($"api/AboutUs/{id}");
        }

        public async Task UpdateAsync(UpdateAboutUsDto updateAboutUsDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/AboutUs", updateAboutUsDto);
            response.EnsureSuccessStatusCode();
        }
    }
}
