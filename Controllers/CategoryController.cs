using AutoMapper;
using Dataflow.Dtos;
using Dataflow.Models;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dataflow.Services;

namespace Dataflow.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCategoryDTO>>>> GetAllCategories()
        {
            var serviceResponse = await _categoryService.GetAllCategories();
            return Ok(serviceResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCategoryDTO>>> GetCategoryById(int id)
        {
            var serviceResponse = await _categoryService.GetCategoryById(id);
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCategoryDTO>>> AddCategory(CreateCategoryDTO newCategory)
        {
            var serviceResponse = await _categoryService.AddCategory(newCategory);
            return CreatedAtAction(nameof(GetCategoryById), new { id = serviceResponse.Data.Id }, serviceResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCategoryDTO>>> UpdateCategory(int id, UpdateCategoryDTO updatedCategory)
        {
            var serviceResponse = await _categoryService.UpdateCategory(id, updatedCategory);
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCategoryDTO>>> DeleteCategory(int id)
        {
            var serviceResponse = await _categoryService.DeleteCategory(id);
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
    }
}
