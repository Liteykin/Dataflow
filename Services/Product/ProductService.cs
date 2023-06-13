using AutoMapper;
using Dataflow.Dtos;
using Dataflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dataflow.Services.ProductService
{
    public class ProductService : IProductService
    {
        private static List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                ProductName = "Product 1",
                Picture = "product1.jpg",
                Description = "Product 1 description",
                InStock = 10,
                Price = 10.99m,
                Rating = 4.5m
            },
            new Product
            {
                Id = 2,
                ProductName = "Product 2",
                Picture = "product2.jpg",
                Description = "Product 2 description",
                InStock = 5,
                Price = 15.99m,
                Rating = 3.8m
            }
        };


        private readonly IMapper _mapper;

        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetProductDTO>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDTO>>();
            serviceResponse.Data = _mapper.Map<List<GetProductDTO>>(_products);
            serviceResponse.Success = true;
            serviceResponse.Message = "All products retrieved.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDTO>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProductDTO>();
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                serviceResponse.Data = _mapper.Map<GetProductDTO>(product);
                serviceResponse.Success = true;
                serviceResponse.Message = "Product retrieved.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDTO>> AddProduct(CreateProductDTO newProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductDTO>();
            var product = _mapper.Map<Product>(newProduct);
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
            serviceResponse.Data = _mapper.Map<GetProductDTO>(product);
            serviceResponse.Success = true;
            serviceResponse.Message = "Product added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDTO>> DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            var serviceResponse = new ServiceResponse<GetProductDTO>();
            if (product != null)
            {
                _products.Remove(product);
                serviceResponse.Data = _mapper.Map<GetProductDTO>(product);
                serviceResponse.Success = true;
                serviceResponse.Message = "Product deleted.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDTO>> UpdateProduct(int id, UpdateProductDTO updatedProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductDTO>();
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);

            if (existingProduct != null)
            {
                existingProduct.ProductName = updatedProduct.ProductName;
                existingProduct.Picture = updatedProduct.Picture;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.InStock = updatedProduct.InStock;
                existingProduct.Price = updatedProduct.InStockPrice;
                existingProduct.Rating = Convert.ToDecimal(updatedProduct.Rating);

                serviceResponse.Data = _mapper.Map<GetProductDTO>(existingProduct);
                serviceResponse.Success = true;
                serviceResponse.Message = "Product updated.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found.";
            }
            return serviceResponse;
        }

    }
}
