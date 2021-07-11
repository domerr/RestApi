using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly DBModelContainter _context;

        public PricesController(DBModelContainter context)
        {
            _context = context;
        }

        /*
        // GET: api/Prices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prices>>> GetPrice()
        {
            return await _context.Price.ToListAsync();
        }
        */

        // GET: api/Evaluate/5/$
        [HttpGet("evaluate/{Id}/{currency}")]
        public async Task<ActionResult<Prices>> GetEvaluate(long Id, string currency)
        {

            //Find product ID
            var product = await _context.Product.FindAsync(Id);

            if (product == null)
            {
                return NotFound();
            }

            //Find pricelist currency
            var queary1 = from m in _context.Pricelist select m;

            queary1 = queary1.Where(s => s.Currency.Contains(currency));

            if (queary1 == null)
            {
                return NotFound();
            }

            //Find specyfic pricelist with specyfic currency and product
            var queary2 = from m in queary1 select m;

            queary2 = queary2.Where(s => s.Name.Contains(product.Name));
            
            if (queary2 == null)
            {
                return NotFound();
            }

            //Find specyfic price for given ID

            var query = (from Pricelists in queary2
                        select Pricelists.Id).First();


            var prices = await _context.Price.FindAsync(query);

            if (prices == null)
            {
                return NotFound();
            }

            return prices; 
        }

        /*
        // PUT: api/Prices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrices(long id, Prices prices)
        {
            if (id != prices.Id)
            {
                return BadRequest();
            }

            _context.Entry(prices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PricesExists(id))
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

        // POST: api/Prices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prices>> PostPrices(Prices prices)
        {
            _context.Price.Add(prices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrices", new { id = prices.Id }, prices);
        }

        // DELETE: api/Prices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrices(long id)
        {
            var prices = await _context.Price.FindAsync(id);
            if (prices == null)
            {
                return NotFound();
            }

            _context.Price.Remove(prices);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PricesExists(long id)
        {
            return _context.Price.Any(e => e.Id == id);
        }
        */
    }
}
