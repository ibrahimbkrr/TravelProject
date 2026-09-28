using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelProject.Entity.Entities;

namespace TravelProject.Business.Abstract
{
    public interface IAboutUsService
    {
        Task<List<AboutUs>> GetAllAboutUsAsync();
        Task<AboutUs?> GetAboutUsByIdAsync(int id);
        Task AddAboutUsAsync(AboutUs aboutUs);
        Task UpdateAboutUsAsync(AboutUs aboutUs);

        Task DeleteAboutUsAsync(int id);
    }
}
