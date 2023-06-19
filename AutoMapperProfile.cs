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

            // Category mappings
            CreateMap<Category, GetCategoryDTO>();
            CreateMap<GetCategoryDTO, Category>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<Category, UpdateCategoryDTO>();
            CreateMap<UpdateCategoryDTO, Category>();

            // Product mappings
            CreateMap<Product, GetProductDTO>();
            CreateMap<GetProductDTO, Product>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<Product, UpdateProductDTO>();
            CreateMap<UpdateProductDTO, Product>();
        }
    }
}