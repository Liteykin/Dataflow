using Dataflow.Models;

namespace Dataflow.Services.UserService;

public class UserService : IUserService
{
    private static List<User?> _users = new()
    {
        new User()
        {
            Id = 1,
            Username = "admin",
            PasswordHash = "admin",
            Email = "example@example.com",
            FirstName = "Admin",
            LastName = "Admin",
            PhoneNumber = "1234567890",
            CreatedAt = DateTime.Now,
            IsOnline = true,
            ProfilePicUrl = "https://www.gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50"
        },
        new User()
        {
            Id = 2,
            Username = "user",
            PasswordHash = "user",
            Email = "example@example.com",
            FirstName = "User",
            LastName = "User",
            PhoneNumber = "1234567890",
            CreatedAt = DateTime.Now,
            IsOnline = true,
            ProfilePicUrl = "https://www.gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50"
        }
    };

    public async Task<ServiceResponse<List<User?>>> GetAllUsers()
    {
        var serviceResponse = new ServiceResponse<List<User?>>();
        serviceResponse.Data = _users;
        return serviceResponse;
    }

    public async Task<ServiceResponse<User?>> GetUserById(int id)
    {
        var serviceResponse = new ServiceResponse<User?>();
        serviceResponse.Data = _users.FirstOrDefault(u => u?.Id == id);
        return serviceResponse;
    }

    public async Task<ServiceResponse<User?>> AddUser(User? newUser)
    {
        var serviceResponse = new ServiceResponse<User?>();
        _users.Add(newUser);
        serviceResponse.Data = newUser;
        return serviceResponse;
    }

    public async Task<ServiceResponse<User?>> DeleteUser(int id)
    {
        var user = _users.FirstOrDefault(u => u != null && u.Id == id);
        _ = _users.Remove(user);
        _users.Remove(user);
        var serviceResponse = new ServiceResponse<User?>();
        serviceResponse.Data = user;
        return serviceResponse;
    }

    public async Task<ServiceResponse<User?>>PatchUser(int id, User updatedUser)
    {
        var serviceResponse = new ServiceResponse<User?>();
        var existingUser = _users.FirstOrDefault(u => u != null && u.Id == id);

        if (existingUser != null)
        {
            existingUser.Username = updatedUser.Username;
            existingUser.PasswordHash = updatedUser.PasswordHash;
            existingUser.Email = updatedUser.Email;
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.PhoneNumber = updatedUser.PhoneNumber;
            existingUser.CreatedAt = updatedUser.CreatedAt;
            existingUser.IsOnline = updatedUser.IsOnline;
            existingUser.ProfilePicUrl = updatedUser.ProfilePicUrl;
            
            serviceResponse.Data = existingUser;
            return serviceResponse;
            
        }
        serviceResponse.Success = false;
        serviceResponse.Message = "User not found.";
        return serviceResponse;
    }
}