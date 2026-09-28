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
    public class AboutUsManager : IAboutUsService
    {
        private readonly IGenericRepository<AboutUs> _repository;
        public AboutUsManager(IGenericRepository<AboutUs> repository)
        {
            _repository = repository;
        }
        public async Task AddAboutUsAsync(AboutUs aboutUs)
        {
            await _repository.AddAsync(aboutUs);
        }
        public async Task DeleteAboutUsAsync(int id)
        {
            var aboutUs = await _repository.GetByIdAsync(id);
            
            if (aboutUs != null)
            {
                await _repository.DeleteAsync(aboutUs);
            }
            else
            {
                throw new Exception("AboutUs not found");
            }
        }
        public async Task<AboutUs?> GetAboutUsByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<AboutUs>> GetAllAboutUsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdateAboutUsAsync(AboutUs aboutUs)
        {
            await _repository.UpdateAsync(aboutUs);
        }
    }
}
