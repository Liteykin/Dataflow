using Dataflow.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

namespace Dataflow.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly List<Room?> _rooms = new List<Room?>();
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
        _users.Remove(_users.FirstOrDefault(u => u != null && u.Id == id));
        return Ok();
    }
}