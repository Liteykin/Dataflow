using AutoMapper;
using Dataflow.Data;
using Dataflow.Dtos;
using Dataflow.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dataflow.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataflowContext _context;
        private readonly IMapper _mapper;

        public CategoryService(DataflowContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCategoryDTO>>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            var categoryDTOs = _mapper.Map<List<GetCategoryDTO>>(categories);

            var serviceResponse = new ServiceResponse<List<GetCategoryDTO>>();
            serviceResponse.Data = categoryDTOs;
            serviceResponse.Success = true;
            serviceResponse.Message = "All categories retrieved.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCategoryDTO>> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                var categoryDTO = _mapper.Map<GetCategoryDTO>(category);

                var serviceResponse = new ServiceResponse<GetCategoryDTO>();
                serviceResponse.Data = categoryDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "Category retrieved.";
                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<GetCategoryDTO>();
                serviceResponse.Success = false;
                serviceResponse.Message = "Category not found.";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetCategoryDTO>> AddCategory(CreateCategoryDTO newCategory)
        {
            var category = _mapper.Map<Category>(newCategory);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var categoryDTO = _mapper.Map<GetCategoryDTO>(category);

            var serviceResponse = new ServiceResponse<GetCategoryDTO>();
            serviceResponse.Data = categoryDTO;
            serviceResponse.Success = true;
            serviceResponse.Message = "Category added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCategoryDTO>> UpdateCategory(int id, UpdateCategoryDTO updatedCategory)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCategory != null)
            {
                // Update the properties of the existing category object
                // based on the updatedCategory DTO object
                existingCategory.Description = updatedCategory.Description;

                await _context.SaveChangesAsync();

                var categoryDTO = _mapper.Map<GetCategoryDTO>(existingCategory);

                var serviceResponse = new ServiceResponse<GetCategoryDTO>();
                serviceResponse.Data = categoryDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "Category updated.";
                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<GetCategoryDTO>();
                serviceResponse.Success = false;
                serviceResponse.Message = "Category not found.";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetCategoryDTO>> DeleteCategory(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                var categoryDTO = _mapper.Map<GetCategoryDTO>(category);

                var serviceResponse = new ServiceResponse<GetCategoryDTO>();
                serviceResponse.Data = categoryDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "Category deleted.";
                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<GetCategoryDTO>();
                serviceResponse.Success = false;
                serviceResponse.Message = "Category not found.";
                return serviceResponse;
            }
        }
    }
}
