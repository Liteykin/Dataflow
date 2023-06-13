using Dataflow.Dtos;
using Dataflow.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dataflow.Services.ContactService
{
    public interface IContactService
    {
        Task<ServiceResponse<List<GetContactDTO>>> GetAllContacts();
        Task<ServiceResponse<GetContactDTO>> GetContactById(int id);
        Task<ServiceResponse<GetContactDTO>> AddContact(ContactDTO newContact);
        Task<ServiceResponse<GetContactDTO>> DeleteContact(int id);
        Task<ServiceResponse<GetContactDTO>> UpdateContact(int id, UpdateContactDTO updatedContact);
    }
}