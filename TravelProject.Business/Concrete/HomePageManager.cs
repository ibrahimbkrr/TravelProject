using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelProject.Business.Abstract;
using TravelProject.DataAccess.Abstract;
using TravelProject.Entity.Entities;

namespace TravelProject.Business.Concrete
{
    public class HomePageManager : IHomePageService
    {
        private readonly IGenericRepository<HomePage> _repository;

        public HomePageManager(IGenericRepository<HomePage> repository)
        {
            _repository = repository;
        }

        public async Task<List<HomePage>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<HomePage?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(HomePage homePage)
        {
            await _repository.AddAsync(homePage);
        }

        public async Task UpdateAsync(HomePage homePage)
        {
            await _repository.UpdateAsync(homePage);
        }

        public async Task DeleteAsync(int id)
        {
            var homePage = await _repository.GetByIdAsync(id);

            if (homePage != null)
            {
                await _repository.DeleteAsync(homePage);
            }
        }
    }
}
