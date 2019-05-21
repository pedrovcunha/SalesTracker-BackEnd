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
    [Route("api/PromotionalAgencies")]
    [ApiController]
    public class PromotionalAgenciesController : ControllerBase
    {
        private readonly Salestrackerdbcontext _context;

        public PromotionalAgenciesController(Salestrackerdbcontext context)
        {
            _context = context;
        }

        // GET: api/PromotionalAgencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionalAgencies>>> GetPromotionalAgencies()
        {
            return await _context.PromotionalAgencies.ToListAsync();
        }

        // GET: api/PromotionalAgencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionalAgencies>> GetPromotionalAgencies(int id)
        {
            var promotionalAgencies = await _context.PromotionalAgencies.FindAsync(id);

            if (promotionalAgencies == null)
            {
                return NotFound();
            }

            return promotionalAgencies;
        }

        // PUT: api/PromotionalAgencies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotionalAgencies(int id, PromotionalAgencies promotionalAgencies)
        {
            promotionalAgencies.Id = id;
            if (id <= 0)
            {
                return BadRequest();
            }

            _context.Entry(promotionalAgencies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionalAgenciesExists(id))
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

        // POST: api/PromotionalAgencies
        [HttpPost]
        public async Task<ActionResult<PromotionalAgencies>> PostPromotionalAgencies(PromotionalAgencies promotionalAgencies)
        {
            _context.PromotionalAgencies.Add(promotionalAgencies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromotionalAgencies", new { id = promotionalAgencies.Id }, promotionalAgencies);
        }

        // DELETE: api/PromotionalAgencies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PromotionalAgencies>> DeletePromotionalAgencies(int id)
        {
            var promotionalAgencies = await _context.PromotionalAgencies.FindAsync(id);
            if (promotionalAgencies == null)
            {
                return NotFound();
            }

            _context.PromotionalAgencies.Remove(promotionalAgencies);
            await _context.SaveChangesAsync();

            return promotionalAgencies;
        }

        private bool PromotionalAgenciesExists(int id)
        {
            return _context.PromotionalAgencies.Any(e => e.Id == id);
        }
    }
}
