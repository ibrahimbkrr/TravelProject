using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelProject.Entity.Entities;

namespace TravelProject.Business.Abstract
{
    public interface IHomePageService
    {
        Task<List<HomePage>> GetAllAsync();
        Task<HomePage?> GetByIdAsync(int id);
        Task AddAsync(HomePage homePage);
        Task UpdateAsync(HomePage homePage);
        Task DeleteAsync(int id);
    }
}
