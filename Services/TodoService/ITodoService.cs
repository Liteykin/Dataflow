using Dataflow.Dtos;
using System.Threading.Tasks;
using Dataflow.Models;

namespace Dataflow.Services.TodosService
{
    public interface ITodoService
    {
        Task<ServiceResponse<List<GetTodoDTO>>> GetAllTodos();
        Task<ServiceResponse<GetTodoDTO>> GetTodoById(int id);
        Task<ServiceResponse<GetTodoDTO>> AddTodo(TodoDTO newTodo);
        Task<ServiceResponse<GetTodoDTO>> UpdateTodo(int id, UpdateTodoDTO updatedTodo);
        Task<ServiceResponse<GetTodoDTO>> DeleteTodoById(int id);
        Task<ServiceResponse<GetTodoDTO>> DeleteTodoByObject(DeleteTodoDTO deleteTodo);
    }
}