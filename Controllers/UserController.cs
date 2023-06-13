using Dataflow.Dtos;
using Dataflow.Models;
using Dataflow.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Dataflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetAllUsers")]
    public async Task<ActionResult<ServiceResponse<List<GetUserDTO>>>> GetAllUsers()
    {
        var response = await _userService.GetAllUsers();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetUserDTO>>> GetUserById(int id)
    {
        var response = await _userService.GetUserById(id);
        return Ok(response);
    }

    [HttpPost("AddUser")]
    public async Task<ActionResult<ServiceResponse<GetUserDTO>>> AddUser(CreateUserDTO newUser)
    {
        var response = await _userService.AddUser(newUser);
        return Ok(response);
    }

    [HttpDelete("DeleteUser/{id}")]
    public async Task<ActionResult<ServiceResponse<GetUserDTO>>> DeleteUser(int id)
    {
        var response = await _userService.DeleteUser(new DeleteUserDTO { Id = id });
        return Ok(response);
    }

    [HttpPatch("PatchUser/{id}")]
    public async Task<ActionResult<ServiceResponse<GetUserDTO>>> PatchUser(int id, UpdateUserDTO user)
    {
        var response = await _userService.PatchUser(id, user);
        return Ok(response);
    }
}