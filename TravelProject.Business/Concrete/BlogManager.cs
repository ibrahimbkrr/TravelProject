using TravelProject.Business.Abstract;
using TravelProject.DataAccess.Abstract;
using TravelProject.Entity.Entities;

namespace TravelProject.Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IGenericRepository<Blog> _repository;

        public BlogManager(IGenericRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Blog blog)
        {
            await _repository.AddAsync(blog);
        }

        public async Task UpdateAsync(Blog blog)
        {
            await _repository.UpdateAsync(blog);
        }

        public async Task DeleteAsync(int id)
        {
            var blog = await _repository.GetByIdAsync(id);

            if (blog != null)
            {
                await _repository.DeleteAsync(blog);
            }
            else
            {
                throw new Exception("Blog not found");
            }
        }
    }
}