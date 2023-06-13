using AutoMapper;
using Dataflow.Dtos;
using Dataflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dataflow.Services.ContactService
{
    public class ContactService : IContactService
    {
        private static List<Contact> _contacts = new()
        {
            new Contact()
            {
                Id = 1,
                UserId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Main St"
            },
            new Contact()
            {
                Id = 2,
                UserId = 1,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "9876543210",
                Address = "456 Elm St"
            }
        };

        private readonly IMapper _mapper;

        public ContactService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetContactDTO>>> GetAllContacts()
        {
            var serviceResponse = new ServiceResponse<List<GetContactDTO>>();
            serviceResponse.Data = _contacts.Select(contact => _mapper.Map<GetContactDTO>(contact)).ToList();

            serviceResponse.Success = true;
            serviceResponse.Message = "All contacts retrieved.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactDTO>> GetContactById(int id)
        {
            var serviceResponse = new ServiceResponse<GetContactDTO>();
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                serviceResponse.Data = _mapper.Map<GetContactDTO>(contact);

                serviceResponse.Success = true;
                serviceResponse.Message = "Contact retrieved.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Contact not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactDTO>> AddContact(ContactDTO newContact)
        {
            var serviceResponse = new ServiceResponse<GetContactDTO>();
            var contact = _mapper.Map<Contact>(newContact);
            contact.Id = GenerateNewContactId();
            _contacts.Add(contact);
            serviceResponse.Data = _mapper.Map<GetContactDTO>(contact);

            serviceResponse.Success = true;
            serviceResponse.Message = "Contact added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactDTO>> DeleteContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            var serviceResponse = new ServiceResponse<GetContactDTO>();
            serviceResponse.Data = _mapper.Map<GetContactDTO>(contact);
            if (contact != null)
            {
                _contacts.Remove(contact);

                serviceResponse.Success = true;
                serviceResponse.Message = "Contact deleted.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Contact not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactDTO>> UpdateContact(int id, UpdateContactDTO updatedContact)
        {
            var serviceResponse = new ServiceResponse<GetContactDTO>();
            var existingContact = _contacts.FirstOrDefault(c => c.Id == id);

            if (existingContact != null)
            {
                existingContact.FirstName = updatedContact.FirstName;
                existingContact.LastName = updatedContact.LastName;
                existingContact.Email = updatedContact.Email;
                existingContact.PhoneNumber = updatedContact.PhoneNumber;
                existingContact.Address = updatedContact.Address;

                serviceResponse.Data = _mapper.Map<GetContactDTO>(existingContact);

                serviceResponse.Success = true;
                serviceResponse.Message = "Contact updated.";
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Contact not found.";
            }
            return serviceResponse;
        }

        private int GenerateNewContactId()
        {
            return _contacts.Max(c => c.Id) + 1;
        }
    }
}
