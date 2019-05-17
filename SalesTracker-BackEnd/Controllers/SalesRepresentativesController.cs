using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.WebAPI.Controllers
{
    [Route("api/SalesRepresentatives")]
    [ApiController]
    public class SalesRepresentativesController : ControllerBase
    {
        private readonly SalestrackerdbContext _context;

        public SalesRepresentativesController(SalestrackerdbContext context)
        {
            _context = context;
        }

        // GET: api/SalesRepresentatives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesRepresentatives>>> GetSalesRepresentatives()
        {
            return await _context.SalesRepresentatives.ToListAsync();
        }

        // GET: api/SalesRepresentatives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesRepresentatives>> GetSalesRepresentatives(int id)
        {
            var salesRepresentatives = await _context.SalesRepresentatives.FindAsync(id);

            if (salesRepresentatives == null)
            {
                return NotFound();
            }

            return salesRepresentatives;
        }

        // PUT: api/SalesRepresentatives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesRepresentatives(int id, SalesRepresentatives salesRepresentatives)
        {
            if (id != salesRepresentatives.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesRepresentatives).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesRepresentativesExists(id))
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

        // POST: api/SalesRepresentatives
        [HttpPost]
        public async Task<ActionResult<SalesRepresentatives>> PostSalesRepresentatives(SalesRepresentatives salesRepresentatives)
        {
            _context.SalesRepresentatives.Add(salesRepresentatives);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesRepresentatives", new { id = salesRepresentatives.Id }, salesRepresentatives);
        }

        // DELETE: api/SalesRepresentatives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesRepresentatives>> DeleteSalesRepresentatives(int id)
        {
            var salesRepresentatives = await _context.SalesRepresentatives.FindAsync(id);
            if (salesRepresentatives == null)
            {
                return NotFound();
            }

            _context.SalesRepresentatives.Remove(salesRepresentatives);
            await _context.SaveChangesAsync();

            return salesRepresentatives;
        }

        private bool SalesRepresentativesExists(int id)
        {
            return _context.SalesRepresentatives.Any(e => e.Id == id);
        }
    }
}
