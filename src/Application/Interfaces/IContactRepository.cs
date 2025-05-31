using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IContactRepository 
    {
        Task<int> CreateContactAsync(Contact contact);
        Task DeleteContactAsync(long id);
        Task<Contact> GetContactByIdAsync(long id);
        Task<List<Contact>> GetContactByUserId(int UserID);
        Task<List<Contact>> GetAllContactsAsync();
        Task UpdateContactAsync(int ContactId, Contact contact);

    }
}
