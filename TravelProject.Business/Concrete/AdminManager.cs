using TravelProject.Business.Abstract;
using TravelProject.DataAccess.Abstract;
using TravelProject.Entity.Entities;

namespace TravelProject.Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IGenericRepository<Admin> _repository;

        public AdminManager(IGenericRepository<Admin> repository)
        {
            _repository = repository;
        }

        public async Task<Admin?> LoginAsync(string userName, string password)
        {
            var admins = await _repository.GetAllAsync();

            return admins.FirstOrDefault(x =>
                x.UserName == userName &&
                x.Password == password);
        }
    }
}