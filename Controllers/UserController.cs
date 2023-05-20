using Dataflow.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dataflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly List<User?> _users = new()
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
            Role = Role.Admin,
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
            Role = Role.User,
            ProfilePicUrl = "https://www.gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50"
        }
    };

    [HttpGet]
    [Route("GetAllUsers")]
    public IActionResult Get()
    {
        return Ok(_users);
    }

    [HttpGet]
    [Route("GetUser")]
    public IActionResult Get(int id)
    {
        return Ok(_users.FirstOrDefault(u => u.Id == id));
    }

    [HttpPost]
    [Route("AddUser")]
    public IActionResult Post(User user)
    {
        _users.Add(user);
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteUser")]
    public IActionResult Delete(int id)
    {
        var user = _users.FirstOrDefault(u => u != null && u.Id == id);
        if (user == null) return NotFound();
        _users.Remove(user);
        return NoContent();
    }

    [HttpPatch]
    [Route("PatchUser")]
    public IActionResult Update(User user)
    {
        var existinguser = _users.FirstOrDefault(u => u != null);
        if (existinguser == null) return NotFound();
        existinguser.Username = user.Username;
        existinguser.PasswordHash = user.PasswordHash;
        existinguser.Email = user.Email;
        existinguser.FirstName = user.FirstName;
        existinguser.LastName = user.LastName;
        existinguser.PhoneNumber = user.PhoneNumber;
        existinguser.LastLogin = user.LastLogin;
        existinguser.IsOnline = user.IsOnline;
        existinguser.Role = user.Role;
        existinguser.ProfilePicUrl = user.ProfilePicUrl;
        return NoContent();
    }
}