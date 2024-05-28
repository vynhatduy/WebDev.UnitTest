﻿using Microservices.product_services.Models;
using Microservices.product_services.Repository;

namespace Microservices.product_services.Service_Layer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            return await _productRepository.AddProductAsync(product);
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            return await _productRepository.UpdateProductAsync(id, product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }
    }
}
