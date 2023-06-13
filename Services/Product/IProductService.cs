using Dataflow.Dtos;
using Dataflow.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dataflow.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDTO>>> GetAllProducts();
        Task<ServiceResponse<GetProductDTO>> GetProductById(int id);
        Task<ServiceResponse<GetProductDTO>> AddProduct(CreateProductDTO newProduct);
        Task<ServiceResponse<GetProductDTO>> DeleteProduct(int id);
        Task<ServiceResponse<GetProductDTO>> UpdateProduct(int id, UpdateProductDTO updatedProduct);
    }
}