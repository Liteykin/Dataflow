using Dataflow.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dataflow.Services;
using Dataflow.Services.TodosService;

namespace Dataflow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("GetAllTodos")]
        public async Task<ActionResult<List<GetTodoDTO>>> GetAllTodos()
        {
            var serviceResponse = await _todoService.GetAllTodos();
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTodoDTO>> GetTodoById(int id)
        {
            var serviceResponse = await _todoService.GetTodoById(id);
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse.Data);
        }

        [HttpPost("AddTodo")]
        public async Task<ActionResult<GetTodoDTO>> AddTodo(TodoDTO newTodo)
        {
            var serviceResponse = await _todoService.AddTodo(newTodo);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse.Data);
        }

        [HttpDelete("DeleteTodo/{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var serviceResponse = await _todoService.DeleteTodoById(id);
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse.Message);
            }
            return Ok(serviceResponse.Data);
        }

        [HttpPut("UpdateTodo/{id}")]
        public async Task<IActionResult> UpdateTodo(int id, UpdateTodoDTO updatedTodo)
        {
            var serviceResponse = await _todoService.UpdateTodo(id, updatedTodo);
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse.Data);
        }
    }
}
