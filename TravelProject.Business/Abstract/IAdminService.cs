using TravelProject.Entity.Entities;

namespace TravelProject.Business.Abstract
{
    public interface IAdminService
    {
        Task<Admin?> LoginAsync(string userName, string password);
    }
}