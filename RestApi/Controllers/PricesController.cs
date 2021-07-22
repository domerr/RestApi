using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [HttpGet("evaluate")]
        public  async Task<ActionResult<IEnumerable<Prices>>> GetEvaluate(string productId, string currency)
        {
            //Separate different product id's and make them long type
            string[] productIdSeparated = productId.Split(',');
            long[] longProductIdSeparated = Array.ConvertAll(productIdSeparated, long.Parse);

            //Separate different currency
            string[] currencySeparated = currency.Split(',');

            //Searching for Pricelists id for currency choosen
            List<String> pricelistsId = new List<String>();
            List<String> pricelistsCurrencyName = new List<String>();

            for (int i = 0; i < currencySeparated.Length; i++)
            {
                var pricelistId = await _context.Pricelist
                  .Where(b => b.Currency == currencySeparated[i])
                  .OrderBy(b => b.Id)
                  .Select(b => new SelectListItem
                  {
                      Value = b.Id.ToString(),
                      Text = b.Name
                  })
                  .ToListAsync();

                foreach (SelectListItem s in pricelistId)
                {
                    pricelistsId.Add(s.Value); //id
                    pricelistsCurrencyName.Add(s.Text);

                }
            }

            //convert list of pricelists ids from string to long
            List<long> longList = pricelistsId.ConvertAll(long.Parse);


            //Searching for specific Prices
            List<Prices> pricesOutput = new List<Prices>();


            //1 currency, product
            if (longList.Count == 1 && longProductIdSeparated.Length == 1)
            {
                pricesOutput = await _context.Price
                .Where(b => b.PricelistId == longList[0]  && b.ProductId == longProductIdSeparated[0] )
                .OrderBy(b => b.Id)
                .Select(b => new Prices
                {
                    Id = b.Id,
                    PricelistId = b.PricelistId,
                    ProductId = b.ProductId,
                    Amount = b.Amount
                })
                .ToListAsync();

            }
            //1 currency, 2 product
            else if (longList.Count == 1 && longProductIdSeparated.Length == 2)
            {
                pricesOutput = await _context.Price
                .Where(b => b.PricelistId == longList[0] && (b.ProductId == longProductIdSeparated[1] || b.ProductId == longProductIdSeparated[0]))
                .OrderBy(b => b.Id)
                .Select(b => new Prices
                {
                    Id = b.Id,
                    PricelistId = b.PricelistId,
                    ProductId = b.ProductId,
                    Amount = b.Amount
                })
                .ToListAsync();

            }
            //1 currency, 3 product
            else if (longList.Count == 1 && longProductIdSeparated.Length == 3)
            {
                pricesOutput = await _context.Price
                .Where(b => b.PricelistId == longList[0] && (b.ProductId == longProductIdSeparated[1] || b.ProductId == longProductIdSeparated[0] || b.ProductId == longProductIdSeparated[2]))
                .OrderBy(b => b.Id)
                .Select(b => new Prices
                {
                    Id = b.Id,
                    PricelistId = b.PricelistId,
                    ProductId = b.ProductId,
                    Amount = b.Amount
                })
                .ToListAsync();
            }
            //1 currency, 4 product
            else if (longList.Count == 1 && longProductIdSeparated.Length == 4)
            {
                pricesOutput = await _context.Price
                .Where(b => b.PricelistId == longList[0] && (b.ProductId == longProductIdSeparated[1] || b.ProductId == longProductIdSeparated[0] || b.ProductId == longProductIdSeparated[2] || b.ProductId == longProductIdSeparated[3]))
                .OrderBy(b => b.Id)
                .Select(b => new Prices
                {
                    Id = b.Id,
                    PricelistId = b.PricelistId,
                    ProductId = b.ProductId,
                    Amount = b.Amount
                })
                .ToListAsync();
            }
            //2 currency, 1 product
            else if (longList.Count == 2 && longProductIdSeparated.Length == 1)
            {
                pricesOutput = await _context.Price
                .Where(b => (b.PricelistId == longList[0] || b.PricelistId == longList[1]) && (b.ProductId == longProductIdSeparated[0]))
                .OrderBy(b => b.Id)
                .Select(b => new Prices
                {
                    Id = b.Id,
                    PricelistId = b.PricelistId,
                    ProductId = b.ProductId,
                    Amount = b.Amount
                })
                .ToListAsync();

            }
            //2 currency, 2 product
            else if (longList.Count == 2 && longProductIdSeparated.Length == 2)
            {
                pricesOutput = await _context.Price
                .Where(b => (b.PricelistId == longList[0] || b.PricelistId == longList[1]) && (b.ProductId == longProductIdSeparated[0] || b.ProductId == longProductIdSeparated[1]))
                .OrderBy(b => b.Id)
                .Select(b => new Prices
                {
                    Id = b.Id,
                    PricelistId = b.PricelistId,
                    ProductId = b.ProductId,
                    Amount = b.Amount
                })
                .ToListAsync();

            }
            //2 currency, 3 product
            else if (longList.Count == 2 && longProductIdSeparated.Length == 3)
            {
                pricesOutput = await _context.Price
                .Where(b => (b.PricelistId == longList[0] || b.PricelistId == longList[1]) && (b.ProductId == longProductIdSeparated[0] || b.ProductId == longProductIdSeparated[1] || b.ProductId == longProductIdSeparated[2]))
                .OrderBy(b => b.Id)
                .Select(b => new Prices
                {
                    Id = b.Id,
                    PricelistId = b.PricelistId,
                    ProductId = b.ProductId,
                    Amount = b.Amount
                })
                .ToListAsync();

            }
            //2 currency, 4 product
            else if (longList.Count == 2 && longProductIdSeparated.Length == 4)
            {
                pricesOutput = await _context.Price
                .Where(b => (b.PricelistId == longList[0] || b.PricelistId == longList[1]) && (b.ProductId == longProductIdSeparated[0] || b.ProductId == longProductIdSeparated[1] || b.ProductId == longProductIdSeparated[2] || b.ProductId == longProductIdSeparated[3]))
                .OrderBy(b => b.Id)
                .Select(b => new Prices
                {
                    Id = b.Id,
                    PricelistId = b.PricelistId,
                    ProductId = b.ProductId,
                    Amount = b.Amount
                })
                .ToListAsync();

            }
            else
            {
                return NotFound();
            }

            return pricesOutput;
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
