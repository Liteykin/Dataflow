using Dataflow.Dtos;
using Dataflow.Models;

namespace Dataflow.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers();
        Task<ServiceResponse<GetUserDTO>> GetUserById(int id);
        Task<ServiceResponse<GetUserDTO>> AddUser(CreateUserDTO newUser);
        Task<ServiceResponse<GetUserDTO>> DeleteUser(DeleteUserDTO deleteUser);
        Task<ServiceResponse<GetUserDTO>> PatchUser(int id, UpdateUserDTO updatedUser);
    }
}