using Dataflow.Dtos;
using Dataflow.Services.ContactService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace Dataflow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private int _lastContactId = 0;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet("GetAllContacts")]
        public async Task<ActionResult<List<GetContactDTO>>> GetAllContacts()
        {
            var serviceResponse = await _contactService.GetAllContacts();
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            var getContactDtos = _mapper.Map<List<GetContactDTO>>(serviceResponse.Data);
            return getContactDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetContactDTO>> GetContactById(int id)
        {
            var serviceResponse = await _contactService.GetContactById(id);
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }
            var getContactDto = _mapper.Map<GetContactDTO>(serviceResponse.Data);
            return getContactDto;
        }

        [HttpPost("AddContact")]
        public async Task<ActionResult<GetContactDTO>> AddContact(AddContactDTO newContact)
        {
            var contactDto = _mapper.Map<ContactDTO>(newContact);
            var serviceResponse = await _contactService.AddContact(contactDto);

            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }

            var getContactDto = _mapper.Map<GetContactDTO>(serviceResponse.Data);
            return getContactDto;
        }

        [HttpDelete("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var serviceResponse = await _contactService.DeleteContact(id);
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }
            var getContactDto = _mapper.Map<GetContactDTO>(serviceResponse.Data);
            return Ok(getContactDto);
        }

        [HttpPatch("UpdateContact/{id}")]
        public async Task<IActionResult> UpdateContact(int id, UpdateContactDTO updatedContact)
        {
            var serviceResponse = await _contactService.UpdateContact(id, updatedContact);
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }
            var getContactDto = _mapper.Map<GetContactDTO>(serviceResponse.Data);
            return Ok(getContactDto);
        }


        private int GenerateNewId()
        {
            _lastContactId++;
            return _lastContactId;
        }
    }
}
