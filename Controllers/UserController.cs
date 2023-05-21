using Dataflow.Models;
using Dataflow.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Dataflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

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

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetAllUsers")]
    public ActionResult<List<User>> Get()
    {
        return Ok(_userService.GetAllUsers());
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        return Ok(_userService.GetUserById(id));
    }

    [HttpPost("AddUser")]
    public ActionResult<User> Post(User newUser)
    {
        return Ok(_userService.AddUser(newUser));
    }

    [HttpDelete("DeleteUser/{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(_userService.DeleteUser(id));
    }


    [HttpPatch("PatchUser/{id}")]
    public IActionResult Patch(int id, User user)
    {
        return Ok(_userService.PatchUser(id, user));
    }
}