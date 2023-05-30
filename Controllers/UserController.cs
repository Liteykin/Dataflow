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
    public async Task<ActionResult<List<GetUserDTO>>> Get()
    {
        return Ok(await _userService.GetAllUsers());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserDTO>> Get(int id)
    {
        return Ok(await _userService.GetUserById(id));
    }

    [HttpPost("AddUser")]
    public async Task<ActionResult<AddUserDTO>> Post(AddUserDTO newUser)
    {
        return Ok(await _userService.AddUser(newUser));
    }

    [HttpDelete("DeleteUser/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _userService.DeleteUser(id));
    }


    [HttpPatch("PatchUser/{id}")]
    public async Task<IActionResult> Patch(int id, AddUserDTO user)
    {
        return Ok(await _userService.PatchUser(id, user));
    }
}