using Dataflow.Dtos;
using Dataflow.Models;

namespace Dataflow.Services.UserService;

public interface IUserService
{
    Task<ServiceResponse<List<GetUserDTO?>>> GetAllUsers();
    Task<ServiceResponse<GetUserDTO?>> GetUserById(int id);
    Task<ServiceResponse<GetUserDTO?>> AddUser(AddUserDTO? newUser);
    Task<ServiceResponse<GetUserDTO>> DeleteUser(int id);
    Task<ServiceResponse<GetUserDTO?>> PatchUser(int id, AddUserDTO updatedUser);
}