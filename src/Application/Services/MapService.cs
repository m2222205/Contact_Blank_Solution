using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MapService
    {
        public static Contact ConvertToContactEntity(CreateContactDto dto)
        {
            return new Contact
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
            };
        }

        public static GetContactDto ConverToContactDto(Contact contact)
        {
            return new GetContactDto
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Address = contact.Address,
            };
        }


    }
}
