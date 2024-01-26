using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProductWebAPI.Data;
using ProductWebAPI.Models;
using System.Runtime.CompilerServices;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDBContext _productDBContext;

        public ProductController(ProductDBContext productDBContext) 
        {
            _productDBContext = productDBContext;
        }

        // GET PRODUCTS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if(_productDBContext.Product == null)
            {
                return NotFound();
            }
            return await _productDBContext.Product.ToListAsync();
        }

        // get productbys id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            if(_productDBContext.Product == null) { 
            return NotFound();
            }
            var product = await _productDBContext.Product.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return product;
        }

        // post product:
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct( [FromBody] Product product)
        {
            if(product == null)
            {
                return Problem(" Entity set ProductDBContext.ProductWebAPI is null");

            }
            //var model = new Product()
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Price = product.Price,
            //    categoryid = product.categoryid,
            //};
           // _productDBContext.Product.Add(model);
           _productDBContext.Product.Add(product);
            await _productDBContext.SaveChangesAsync(); 
            return CreatedAtAction("GetProducts",new {id = product.Id} , product);
        }

        // Delete Product
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            if(_productDBContext.Product == null)
            {
                return NotFound();
            }
            var product = await _productDBContext.Product.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            _productDBContext.Product.Remove(product);
            await _productDBContext.SaveChangesAsync();
            return NoContent();
        }

      // guid id exists

        private bool ProductExist(Guid id)
        {
            return (_productDBContext?.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // updated the product records based on the guid
        [HttpPut("{id}")]

        public async Task<ActionResult<Product>> UpdateProduct( Guid id , Product product )
        {
            if(id != product.Id)
            {
                return BadRequest();
            } 
            _productDBContext.Entry(product).State = EntityState.Modified;
            try{
                await _productDBContext.SaveChangesAsync(); 
            }catch(DbUpdateConcurrencyException)
            {
                if(!ProductExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            // return NoContent();
            return product;
        }
    }
}
