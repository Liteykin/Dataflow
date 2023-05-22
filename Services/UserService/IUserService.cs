using Dataflow.Models;

namespace Dataflow.Services.UserService;

public interface IUserService
{
    Task<ServiceResponse<List<User?>>> GetAllUsers();
    Task<ServiceResponse<User?>> GetUserById(int id);
    Task<ServiceResponse<User?>> AddUser(User? newUser);
    Task<ServiceResponse<User?>> DeleteUser(int id);
    Task<ServiceResponse<User?>> PatchUser(int id, User updatedUser);
}