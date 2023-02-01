using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Model;

namespace ProductApi.Controllers
{
    [Route("(api/controller)")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/products")]
        public async Task<ActionResult> GetAllProduct()
        {
            return Ok (await _context.Products.ToListAsync());
        }

        [HttpPost]
        [Route("/products")]
        public async Task<ActionResult> CreateProduct(ProductModel product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut]
        [Route("/products")]
        public async Task<ActionResult> UpdateProduct(ProductModel product)
        {
            var dbProduct = await _context.Products.FindAsync(product.Id);

            if(dbProduct == null)
                return NotFound();

            dbProduct.Id = product.Id;
            dbProduct.Name = product.Name;
            dbProduct.Category= product.Category;

            await _context.SaveChangesAsync();
            return Ok(dbProduct);
        }

        [HttpDelete]
        [Route("/products")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var dbProduct = await _context.Products.FindAsync(id);

            if (dbProduct == null)
                return NotFound();

            _context.Products.Remove(dbProduct);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
