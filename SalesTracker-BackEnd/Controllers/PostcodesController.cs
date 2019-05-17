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
    [Route("api/Postcodes")]
    [ApiController]
    public class PostcodesController : ControllerBase
    {
        private readonly SalestrackerdbContext _context;

        public PostcodesController(SalestrackerdbContext context)
        {
            _context = context;
        }

        // GET: api/Postcodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Postcodes>>> GetPostcodes()
        {
            return await _context.Postcodes.ToListAsync();
        }

        // GET: api/Postcodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Postcodes>> GetPostcodes(int id)
        {
            var postcodes = await _context.Postcodes.FindAsync(id);

            if (postcodes == null)
            {
                return NotFound();
            }

            return postcodes;
        }

        // PUT: api/Postcodes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostcodes(int id, Postcodes postcodes)
        {
            if (id != postcodes.Id)
            {
                return BadRequest();
            }

            _context.Entry(postcodes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostcodesExists(id))
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

        // POST: api/Postcodes
        [HttpPost]
        public async Task<ActionResult<Postcodes>> PostPostcodes(Postcodes postcodes)
        {
            _context.Postcodes.Add(postcodes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostcodes", new { id = postcodes.Id }, postcodes);
        }

        // DELETE: api/Postcodes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Postcodes>> DeletePostcodes(int id)
        {
            var postcodes = await _context.Postcodes.FindAsync(id);
            if (postcodes == null)
            {
                return NotFound();
            }

            _context.Postcodes.Remove(postcodes);
            await _context.SaveChangesAsync();

            return postcodes;
        }

        private bool PostcodesExists(int id)
        {
            return _context.Postcodes.Any(e => e.Id == id);
        }
    }
}
