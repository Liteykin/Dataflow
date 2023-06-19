using AutoMapper;
using Dataflow.Dtos;
using Dataflow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dataflow.Data;

namespace Dataflow.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly DataflowContext _context;
        private readonly IMapper _mapper;

        public ContactService(DataflowContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetContactDTO>>> GetAllContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            var contactDTOs = _mapper.Map<List<GetContactDTO>>(contacts);

            var serviceResponse = new ServiceResponse<List<GetContactDTO>>();
            serviceResponse.Data = contactDTOs;
            serviceResponse.Success = true;
            serviceResponse.Message = "All contacts retrieved.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactDTO>> GetContactById(int id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (contact != null)
            {
                var contactDTO = _mapper.Map<GetContactDTO>(contact);

                var serviceResponse = new ServiceResponse<GetContactDTO>();
                serviceResponse.Data = contactDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "Contact retrieved.";
                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<GetContactDTO>();
                serviceResponse.Success = false;
                serviceResponse.Message = "Contact not found.";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetContactDTO>> AddContact(ContactDTO newContact)
        {
            var contact = _mapper.Map<Contact>(newContact);
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            var contactDTO = _mapper.Map<GetContactDTO>(contact);

            var serviceResponse = new ServiceResponse<GetContactDTO>();
            serviceResponse.Data = contactDTO;
            serviceResponse.Success = true;
            serviceResponse.Message = "Contact added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactDTO>> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();

                var contactDTO = _mapper.Map<GetContactDTO>(contact);

                var serviceResponse = new ServiceResponse<GetContactDTO>();
                serviceResponse.Data = contactDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "Contact deleted.";
                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<GetContactDTO>();
                serviceResponse.Success = false;
                serviceResponse.Message = "Contact not found.";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetContactDTO>> UpdateContact(int id, UpdateContactDTO updatedContact)
        {
            var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (existingContact != null)
            {
                existingContact.FirstName = updatedContact.FirstName;
                existingContact.LastName = updatedContact.LastName;
                existingContact.Email = updatedContact.Email;
                existingContact.PhoneNumber = updatedContact.PhoneNumber;
                existingContact.Address = updatedContact.Address;

                await _context.SaveChangesAsync();

                var contactDTO = _mapper.Map<GetContactDTO>(existingContact);

                var serviceResponse = new ServiceResponse<GetContactDTO>();
                serviceResponse.Data = contactDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "Contact updated.";
                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<GetContactDTO>();
                serviceResponse.Success = false;
                serviceResponse.Message = "Contact not found.";
                return serviceResponse;
            }
        }
    }
}
