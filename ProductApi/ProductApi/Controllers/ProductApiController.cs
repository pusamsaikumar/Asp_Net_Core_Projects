using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly ProductsApiDBContext _context;

       public  ProductApiController(ProductsApiDBContext context)
        {
            _context = context;
        }
        // get products /api/products
        [HttpGet]
    /*    public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
              if(_context.Product == null)
            {
                return NotFound();
            }
            return  await _context.Product.ToListAsync();
            }*/

        public async Task<IActionResult> GetProduct()
        {

          

            var data = await _context.Product.ToListAsync();
            return Ok(data);
        }

        // get products by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct( int id)
        {
                if(_context.Product == null)
            {
                return NotFound(); 
            }
                var product = await _context.Product.FindAsync(id);
            if(product == null)
            {
                return NotFound();  
            }
            //  return Ok(product);
            return product;
        }
        // create product 
        [HttpPost]
        //public async Task<ActionResult<Product>> CreateProduct(Product product)
        //{
        //    if(_context.Products == null)
        //    {
        //        return Problem("Entity set of ProductsApiDBContext.Product is null");
        //    }
        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();  
        //    return CreatedAtAction("GetProducts", new { id = product.Id}, product);
        //}

        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ProductsApiDBContext.Product'  is null.");
            }
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }
    }
}
