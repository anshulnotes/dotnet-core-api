using System;
using System.Threading.Tasks;
using DotNetCore.BusinessServices;
using DotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DotNetCore.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPut]
        public async Task<IActionResult> UpsertProduct([FromBody]Product product)
        {
            var isSuccess = await _productService.UpsertProduct(product);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var product = await _productService.GetProduct(id);

            return Ok(product);
        }
    }
}