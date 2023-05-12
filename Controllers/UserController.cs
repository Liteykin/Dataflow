using Dataflow.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dataflow.Controllers;

public class UserController : ControllerBase
{
    private readonly List<User> _users = new()
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
            LastLogin = DateTime.Now,
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
            LastLogin = DateTime.Now,
            IsOnline = true,
            ProfilePicUrl = "https://www.gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50"
        }
    };
}