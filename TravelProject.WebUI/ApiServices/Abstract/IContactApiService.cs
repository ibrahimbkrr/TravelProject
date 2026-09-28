using TravelProject.Dto.ContactDtos;

namespace TravelProject.WebUI.ApiServices.Abstract
{
    public interface IContactApiService
    {
        Task<List<ResultContactDto>> GetAllAsync();
        Task<ResultContactDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateContactDto createContactDto);
        Task UpdateAsync(UpdateContactDto updateContactDto);
        Task DeleteAsync(int id);
    }
}