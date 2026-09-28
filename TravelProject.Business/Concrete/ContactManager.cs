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
    public class ContactManager : IContactService
    {
        private readonly IGenericRepository<Contact> _repository;

        public ContactManager(IGenericRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task AddContactAsync(Contact contact)
        {
           await _repository.AddAsync(contact);
        }

        public Task DeleteContactAsync(int id)
        {
            var contact = _repository.GetByIdAsync(id).Result;
            if (contact != null)
            {
                return _repository.DeleteAsync(contact);
            }
            else
            {
                throw new Exception("Contact not found");
            }
        }

        public Task<List<Contact>> GetAllContactAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Contact?> GetContactByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task UpdateContactAsync(Contact contact)
        {
            return _repository.UpdateAsync(contact);
        }
    }
}
