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
    public class PricelistsController : ControllerBase
    {
        private readonly DBModelContainter _context;

        public PricelistsController(DBModelContainter context)
        {
            _context = context;
        }

        /*
        // GET: api/Pricelists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pricelists>>> GetPricelist()
        {
            return await _context.Pricelist.ToListAsync();
        }

        */

        // GET: api/Pricelists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pricelists>> GetPricelists(long id)
        {
            var pricelists = await _context.Pricelist.FindAsync(id);

            if (pricelists == null)
            {
                return NotFound();
            }

            return pricelists;
        }

        /*
        // PUT: api/Pricelists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPricelists(long id, Pricelists pricelists)
        {
            if (id != pricelists.Id)
            {
                return BadRequest();
            }

            _context.Entry(pricelists).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PricelistsExists(id))
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
        */

        // POST: api/Pricelists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pricelists>> PostPricelists(Pricelists pricelists)
        {
            _context.Pricelist.Add(pricelists);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPricelists", new { id = pricelists.Id }, pricelists);
        }

        /*
        // DELETE: api/Pricelists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricelists(long id)
        {
            var pricelists = await _context.Pricelist.FindAsync(id);
            if (pricelists == null)
            {
                return NotFound();
            }

            _context.Pricelist.Remove(pricelists);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PricelistsExists(long id)
        {
            return _context.Pricelist.Any(e => e.Id == id);
        }
        */
    }
}
