using AutoMapper;
using Dataflow.Dtos;
using Dataflow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dataflow.Data;

namespace Dataflow.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataflowContext _context;
        private readonly IMapper _mapper;

        public ProductService(DataflowContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetProductDTO>>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            var productDTOs = _mapper.Map<List<GetProductDTO>>(products);

            var serviceResponse = new ServiceResponse<List<GetProductDTO>>();
            serviceResponse.Data = productDTOs;
            serviceResponse.Success = true;
            serviceResponse.Message = "All products retrieved.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDTO>> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                var productDTO = _mapper.Map<GetProductDTO>(product);

                var serviceResponse = new ServiceResponse<GetProductDTO>();
                serviceResponse.Data = productDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "Product retrieved.";
                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<GetProductDTO>();
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found.";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetProductDTO>> AddProduct(CreateProductDTO newProduct)
        {
            var product = _mapper.Map<Product>(newProduct);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var productDTO = _mapper.Map<GetProductDTO>(product);

            var serviceResponse = new ServiceResponse<GetProductDTO>();
            serviceResponse.Data = productDTO;
            serviceResponse.Success = true;
            serviceResponse.Message = "Product added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDTO>> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                var productDTO = _mapper.Map<GetProductDTO>(product);

                var serviceResponse = new ServiceResponse<GetProductDTO>();
                serviceResponse.Data = productDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "Product deleted.";
                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<GetProductDTO>();
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found.";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetProductDTO>> UpdateProduct(int id, UpdateProductDTO updatedProduct)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existingProduct != null)
            {
                existingProduct.ProductName = updatedProduct.ProductName;
                existingProduct.Picture = updatedProduct.Picture;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.InStock = updatedProduct.InStock;
                existingProduct.Price = updatedProduct.InStockPrice;
                existingProduct.Rating = Convert.ToDecimal(updatedProduct.Rating);

                await _context.SaveChangesAsync();

                var productDTO = _mapper.Map<GetProductDTO>(existingProduct);

                var serviceResponse = new ServiceResponse<GetProductDTO>();
                serviceResponse.Data = productDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "Product updated.";
                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<GetProductDTO>();
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found.";
                return serviceResponse;
            }
        }
    }
}
