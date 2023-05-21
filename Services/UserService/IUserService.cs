using Dataflow.Models;

namespace Dataflow.Services.UserService;

public interface IUserService
{
    List<User?> GetAllUsers();
    User? GetUserById(int id);
    List<User?> AddUser(User? newUser);
    bool DeleteUser(int id);
    User? PatchUser(int id, User updatedUser);
}