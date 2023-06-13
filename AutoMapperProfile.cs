using AutoMapper;
using Dataflow.Dtos;
using Dataflow.Models;

namespace Dataflow
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Contact mappings
            CreateMap<Contact, GetContactDTO>();
            CreateMap<GetContactDTO, Contact>();

            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();

            CreateMap<Contact, UpdateContactDTO>();
            CreateMap<UpdateContactDTO, Contact>();

            // Todo mappings
            CreateMap<Todo, GetTodoDTO>();
            CreateMap<GetTodoDTO, Todo>();

            CreateMap<Todo, TodoDTO>();
            CreateMap<TodoDTO, Todo>();

            CreateMap<Todo, UpdateTodoDTO>();
            CreateMap<UpdateTodoDTO, Todo>();

            // User mappings
            CreateMap<User, GetUserDTO>();
            CreateMap<GetUserDTO, User>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<User, UpdateUserDTO>();
            CreateMap<UpdateUserDTO, User>();
        }
    }
}