using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BergerSebastien1.Models;
using System.ComponentModel.DataAnnotations;

namespace BergerSebastien1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SB_ProductController : ControllerBase
    {
        private readonly SB_NorthwindContext _context;

        public SB_ProductController(SB_NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/SB_Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetSB_Product()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/SB_Product/5
        [Route("Product/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/SB_Product/23.25
        [Route("Price/{price}")]
        [DataType(DataType.Currency)]
        [HttpGet("{price}")]
        public ActionResult<IEnumerable<Product>> SB_GetProductByPrice(decimal price)
        {
            IEnumerable<Product> SB_product = null;
            var SB_q = from d in _context.Products
                    where d.UnitPrice == price
                    select d;
            SB_product = SB_q;


            if (SB_product.Count() == 0)
            {
                return NotFound();
            }

            return SB_product.ToList();


        }

        // PUT: api/SB_Product/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
