using Dataflow.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dataflow.Models;

namespace Dataflow.Services
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<GetCategoryDTO>>> GetAllCategories();
        Task<ServiceResponse<GetCategoryDTO>> GetCategoryById(int id);
        Task<ServiceResponse<GetCategoryDTO>> AddCategory(CreateCategoryDTO newCategory);
        Task<ServiceResponse<GetCategoryDTO>> UpdateCategory(int id, UpdateCategoryDTO updatedCategory);
        Task<ServiceResponse<GetCategoryDTO>> DeleteCategory(int id);
    }
}