using DotNetCore.DataAccess;
using DotNetCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace DotNetCore.BusinessServices
{
    public interface IProductService
    {
        Task<Product> GetProduct(string id);
        Task<bool> UpsertProduct(Product product);
    }
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository; 
        }
        public async Task<Product> GetProduct(string id)
        {
            return await _productRepository.GetProduct(id);
        }

        public async Task<bool> UpsertProduct(Product product)
        {
            return await _productRepository.UpsertProduct(product);    
        }
    }
}
