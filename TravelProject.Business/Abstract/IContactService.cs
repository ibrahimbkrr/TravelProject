using System.Collections.Generic;
using System.Threading.Tasks;
using TravelProject.Entity.Entities;

namespace TravelProject.Business.Abstract
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContactAsync();
        Task<Contact?> GetContactByIdAsync(int id);
        Task AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(int id);
    }
}