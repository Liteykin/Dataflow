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
            Tier = Tier.Tier3,
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
            Tier = Tier.Tier1,
            ProfilePicUrl = "https://www.gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50"
        }
    };

    public List<User?> GetAllUsers()
    {
        return _users;
    }

    public User? GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u != null && u.Id == id);
    }

    public List<User?> AddUser(User? newUser)
    {
        _users.Add(newUser);
        return _users;
    }

    public bool DeleteUser(int id)
    {
        var user = _users.FirstOrDefault(u => u != null && u.Id == id);
        if (user == null)
        {
            return false;
        }

        _users.Remove(user);
        return true;
    }

    public User? PatchUser(int id, User updatedUser)
    {
        var existingUser = _users.FirstOrDefault(u => u != null && u.Id == id);
        if (existingUser == null)
        {
            return null;
        }

        existingUser.Username = updatedUser.Username;
        existingUser.PasswordHash = updatedUser.PasswordHash;
        existingUser.Email = updatedUser.Email;
        existingUser.FirstName = updatedUser.FirstName;
        existingUser.LastName = updatedUser.LastName;
        existingUser.PhoneNumber = updatedUser.PhoneNumber;
        existingUser.CreatedAt = updatedUser.CreatedAt;
        existingUser.IsOnline = updatedUser.IsOnline;
        existingUser.Tier = updatedUser.Tier;
        existingUser.ProfilePicUrl = updatedUser.ProfilePicUrl;

        return existingUser;
    }
}