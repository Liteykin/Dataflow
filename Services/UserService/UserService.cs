using AutoMapper;
using Dataflow.Dtos;
using Dataflow.Models;


namespace Dataflow.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                Username = "admin",
                Password = "admin",
                Email = "example@example.com",
                FirstName = "Admin",
                LastName = "Admin",
                RegistrationDate = DateTime.Today
            },
            new User
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
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> AddUser(CreateUserDTO newUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            var user = _mapper.Map<User>(newUser);
            user.Id = _users.Max(u => u.Id) + 1;
            _users.Add(user);
            serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
            serviceResponse.Success = true;
            serviceResponse.Message = "User added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> DeleteUser(DeleteUserDTO deleteUser)
        {
            var user = _users.FirstOrDefault(u => u.Id == deleteUser.Id);
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            if (user != null)
            {
                _users.Remove(user);
                serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
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

        public async Task<ServiceResponse<GetUserDTO>> PatchUser(int id, UpdateUserDTO updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            var existingUser = _users.FirstOrDefault(u => u.Id == id);

            if (existingUser != null)
            {
                existingUser.Username = updatedUser.Username;
                existingUser.Password = updatedUser.Password;
                existingUser.FirstName = updatedUser.FirstName;
                existingUser.LastName = updatedUser.LastName;
                existingUser.Email = updatedUser.Email;

                serviceResponse.Data = _mapper.Map<GetUserDTO>(existingUser);
                serviceResponse.Success = true;
                serviceResponse.Message = "User updated.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found.";
            }
            return serviceResponse;
        }
    }
}