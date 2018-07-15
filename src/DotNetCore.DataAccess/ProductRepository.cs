using DotNetCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace DotNetCore.DataAccess
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(string id);
        Task<bool> UpsertProduct(Product product);
    }

    public class ProductRepository : IProductRepository
    {
        public async Task<Product> GetProduct(string id)
        {
            var client = new MongoClient("mongodb://appcomitapi:comitpwd123!@10.160.165.85:27000");
            var db = client.GetDatabase("itemsDb");
            var coll = db.GetCollection<Product>("testProducts");
            var datetimeOffSetConvertor = new DateTimeOffsetSerializer(BsonType.Array);
            var productCur = await coll.FindAsync(p => p.Id == id);
            var product = productCur.FirstOrDefault();

            return product;
        }

        public async Task<bool> UpsertProduct(Product product)
        {
            var client = new MongoClient("mongodb://appcomitapi:comitpwd123!@10.160.165.85:27000");
            var db = client.GetDatabase("itemsDb");
            var coll = db.GetCollection<Product>("testProducts");

            var p1 = new Product
            {
                Id = "1",
                EffectiveDate = DateTime.Now,
                EffectiveDateStr = null,
                UpdatedDate = null,
                UpdatedDateStr = null
            };

            var p2 = new Product
            {
                Id = "2",
                EffectiveDate = null,
                EffectiveDateStr = DateTime.Now.ToString(),
                UpdatedDate = null,
                UpdatedDateStr = null
            };
            var p3 = new Product
            {
                Id = "3",
                EffectiveDate = null,
                EffectiveDateStr = null,
                UpdatedDate = DateTimeOffset.Now,
                UpdatedDateStr = null
            };
            var p4 = new Product
            {
                Id = "4",
                EffectiveDate = null,
                EffectiveDateStr = null,
                UpdatedDate = null,
                UpdatedDateStr = DateTimeOffset.Now.ToString()
            };
            await coll.InsertOneAsync(p1);
            await coll.InsertOneAsync(p2);
            await coll.InsertOneAsync(p3);
            await coll.InsertOneAsync(p4);

            return true;
        }
    }
}
