using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Persistence.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly Maincontext maincontext;

        public ContactRepository(Maincontext _maincontext)
        {
            maincontext = _maincontext;
        }

        public async Task<int> CreateContactAsync(Contact contact)
        {
            await maincontext.Contacts.AddAsync(contact);
            maincontext.SaveChanges();
            return contact.Id;

        }

        public async Task DeleteContactAsync(long id)
        {
            var contact = await GetContactByIdAsync(id);
            maincontext.Contacts.Remove(contact);
            maincontext.SaveChanges();
        }

        public Task<List<Contact>> GetAllContactsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Contact> GetContactByIdAsync(long id)
        {
            var contact = await maincontext.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (contact == null)
            {
                throw new Exception($"Contact with that {id} not found");
            }

            return contact;
        }

        public async Task<List<Contact>> GetContactByUserId(int UserID)
        {
            var contacts = await maincontext.Contacts.Where(c => c.User.UserId == UserID).ToListAsync();
            return contacts;
        }

        public async Task UpdateContactAsync(int ContactId, Contact contact)
        {
            maincontext.Contacts.Update(contact);
            await maincontext.SaveChangesAsync();
        }
    }
}
