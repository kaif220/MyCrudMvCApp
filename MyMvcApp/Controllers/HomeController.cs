using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 50000 }
        };

        // READ - GET
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        // READ by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = products.Max(x => x.Id) + 1;
            products.Add(product);
            return Ok(product);
        }

        // UPDATE - PUT
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            var existing = products.FirstOrDefault(x => x.Id == id);
            if (existing == null) return NotFound();

            existing.Name = product.Name;
            existing.Price = product.Price;

            return Ok(existing);
        }

        // DELETE - DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();

            products.Remove(product);
            return Ok("Deleted Successfully");
        }
    }
}
