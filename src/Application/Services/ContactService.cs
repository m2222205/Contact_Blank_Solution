using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContactService
    {
        private readonly IContactRepository contactRepository;
        public ContactService(IContactRepository ContactRepository)
        {
            contactRepository = ContactRepository;
        }

        public async Task DeleteAsync(long contactId)
        {
            var contact = await contactRepository.GetContactByIdAsync(contactId);
            if (contact == null)
            {
                throw new Exception($"Contact not fount to delete with id {contactId}");
            }
            await contactRepository.DeleteContactAsync(contact.Id);
        }

        public ICollection<GetContactDto> GetAll()
        {
            var query = contactRepository.GetAllContactsAsync();
            var contacts = query.ToList();

            var contactDtos = contacts.Select(c => MapService.ConverToContactDto(c)).ToList();
            return contactDtos;
        }

        public async Task<GetContactDto> GetByIdAsync(long contactId)
        {
            var contact = await contactRepository.GetContactByIdAsync(contactId);
            if (contact == null)
            {
                throw new Exception($"Contact not fount with id {contactId}");
            }
            return MapService.ConverToContactDto(contact);
        }

        public async Task<long> PostAsync(CreateContactDto contact)
        {
            var contactToDB = MapService.ConvertToContactEntity(contact);
            var contactId = await contactRepository.CreateContactAsync(contactToDB);
            return contactId;
        }

        public async Task UpdateAsync(GetContactDto contactDto)
        {
            var convert = MapService.ConvertToContactEntity(contactDto);
            var contact = await contactRepository.GetContactByIdAsync(contactDto);
            if (contact == null)
            {
                throw new Exception($"Contact not fount to update with id {contactDto.ContactId}");
            }

            contact.Phone = contactDto.Phone;
            contact.Email = contactDto.Email;
            contact.Address = contactDto.Address;
            contact.Name = contactDto.Name;

            await contactRepository.UpdateContactAsync(contact);
        }




    }
}
