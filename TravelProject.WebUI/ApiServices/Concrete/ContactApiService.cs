using System.Net.Http.Json;
using TravelProject.Dto.ContactDtos;
using TravelProject.WebUI.ApiServices.Abstract;

namespace TravelProject.WebUI.ApiServices.Concrete
{
    public class ContactApiService : IContactApiService
    {
        private readonly HttpClient _httpClient;

        public ContactApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            var response =
                await _httpClient.GetFromJsonAsync<List<ResultContactDto>>(
                    "api/Contact");

            return response ?? new List<ResultContactDto>();
        }

        public async Task<ResultContactDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResultContactDto>(
                $"api/Contact/{id}");
        }

        public async Task CreateAsync(CreateContactDto createContactDto)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Contact",
                createContactDto);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(UpdateContactDto updateContactDto)
        {
            var response = await _httpClient.PutAsJsonAsync(
                "api/Contact",
                updateContactDto);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response =
                await _httpClient.DeleteAsync($"api/Contact/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}