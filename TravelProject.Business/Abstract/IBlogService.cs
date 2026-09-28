using TravelProject.Entity.Entities;

namespace TravelProject.Business.Abstract
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);
        Task AddAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task DeleteAsync(int id);
    }
}