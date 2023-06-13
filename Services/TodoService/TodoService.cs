using AutoMapper;
using Dataflow.Dtos;
using Dataflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dataflow.Services.TodosService;

namespace Dataflow.Services.TodoService
{
    public class TodoService : ITodoService
    {
        private static List<Todo> _todos = new List<Todo>();

        private readonly IMapper _mapper;

        public TodoService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetTodoDTO>>> GetAllTodos()
        {
            var serviceResponse = new ServiceResponse<List<GetTodoDTO>>();
            serviceResponse.Data = _todos.Select(todo => _mapper.Map<GetTodoDTO>(todo)).ToList();
            serviceResponse.Success = true;
            serviceResponse.Message = "All to-do items retrieved.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoDTO>> GetTodoById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTodoDTO>();
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                serviceResponse.Data = _mapper.Map<GetTodoDTO>(todo);
                serviceResponse.Success = true;
                serviceResponse.Message = "To-do item retrieved.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "To-do item not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoDTO>> AddTodo(TodoDTO newTodo)
        {
            var serviceResponse = new ServiceResponse<GetTodoDTO>();
            var todo = _mapper.Map<Todo>(newTodo);
            todo.Id = _todos.Count + 1;
            todo.CreatedAt = DateTime.Now;
            todo.UpdatedAt = DateTime.Now;
            _todos.Add(todo);
            serviceResponse.Data = _mapper.Map<GetTodoDTO>(todo);
            serviceResponse.Success = true;
            serviceResponse.Message = "To-do item added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoDTO>> UpdateTodo(int id, UpdateTodoDTO updatedTodo)
        {
            var serviceResponse = new ServiceResponse<GetTodoDTO>();
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                todo.Title = updatedTodo.Title;
                todo.Description = updatedTodo.Description;
                todo.DueDate = updatedTodo.DueDate;
                todo.IsCompleted = updatedTodo.IsCompleted;
                todo.UpdatedAt = DateTime.Now;
                serviceResponse.Data = _mapper.Map<GetTodoDTO>(todo);
                serviceResponse.Success = true;
                serviceResponse.Message = "To-do item updated.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "To-do item not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoDTO>> DeleteTodoById(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            var serviceResponse = new ServiceResponse<GetTodoDTO>();
            if (todo != null)
            {
                _todos.Remove(todo);
                serviceResponse.Data = _mapper.Map<GetTodoDTO>(todo);
                serviceResponse.Success = true;
                serviceResponse.Message = "To-do item deleted.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "To-do item not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoDTO>> DeleteTodoByObject(DeleteTodoDTO deleteTodo)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == deleteTodo.Id);
            var serviceResponse = new ServiceResponse<GetTodoDTO>();
            if (todo != null)
            {
                _todos.Remove(todo);
                serviceResponse.Data = _mapper.Map<GetTodoDTO>(todo);
                serviceResponse.Success = true;
                serviceResponse.Message = "To-do item deleted.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "To-do item not found.";
            }
            return serviceResponse;
        }
    }
}
