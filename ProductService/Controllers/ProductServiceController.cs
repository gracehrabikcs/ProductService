using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> Products = new()
        {
            new Product { ProductId = 1, ProductName = "Laptop", Price = 1200 },
            new Product { ProductId = 2, ProductName = "Phone", Price = 800 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => Ok(Products);

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = Products.FirstOrDefault(p => p.ProductId == id);
            return product is not null ? Ok(product) : NotFound();
        }
    }
}
