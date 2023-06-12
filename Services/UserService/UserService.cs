using AutoMapper;
using Dataflow.Dtos;
using Dataflow.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dataflow.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> _users = new()
        {
            new User()
            {
                Id = 1,
                Username = "admin",
                Password = "admin",
                Email = "example@example.com",
                FirstName = "Admin",
                LastName = "Admin",
                RegistrationDate = DateTime.Today
            },
            new User()
            {
                Id = 2,
                Username = "user",
                Password = "user",
                Email = "example@example.com",
                FirstName = "User",
                LastName = "User",
                RegistrationDate = DateTime.Today
            }
        };

        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDTO>>();
            serviceResponse.Data = _users.Select(user => _mapper.Map<GetUserDTO>(user)).ToList();
            
            serviceResponse.Success = true;
            serviceResponse.Message = "All users retrieved.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
                
                serviceResponse.Success = true;
                serviceResponse.Message = "User retrieved.";
            } else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> AddUser(AddUserDTO newUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            _users.Add(_mapper.Map<User>(newUser));
            serviceResponse.Data = _users.Select(u => _mapper.Map<GetUserDTO>(u)).FirstOrDefault();
            
            serviceResponse.Success = true;
            serviceResponse.Message = "User added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
            if (user != null)
            {
                _users.Remove(user);
                
                serviceResponse.Success = true;
                serviceResponse.Message = "User deleted.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> PatchUser(int id, AddUserDTO updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            var existingUser = _users.FirstOrDefault(u => u.Id == id);

            if (existingUser != null)
            {
                existingUser.Id = 1;
                existingUser.Username = updatedUser.Username;
                existingUser.Password = updatedUser.Password;
                existingUser.Email = updatedUser.Email;
                existingUser.FirstName = updatedUser.FirstName;
                existingUser.LastName = updatedUser.LastName;
                existingUser.RegistrationDate = DateTime.Today;

                serviceResponse.Data = _mapper.Map<GetUserDTO>(existingUser);
                
                serviceResponse.Success = true;
                serviceResponse.Message = "User updated.";
            } else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found.";
            }
            return serviceResponse;
        }
    }
}
