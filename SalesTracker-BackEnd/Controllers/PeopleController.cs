using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Domain.Contracts.UnitOfWork;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;
using SalesTracker.Infrastructure.Data.UnitOfWork;

namespace SalesTracker.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/People")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly Salestrackerdbcontext _context;

        public PeopleController(Salestrackerdbcontext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<People>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetPeople(int id)
        {
            var People = await _context.People.FindAsync(id);

            if (People == null)
            {
                return NotFound();
            }

            return People;
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeople(int id, People People)
        {
            People.Id = id;
            if (id <= 0)
            {
                return BadRequest();
            }

            _context.Entry(People).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(id))
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

        // POST: api/People
        [HttpPost]
        public async Task<ActionResult<People>> PostPeople(People People)
        {
            _context.People.Add(People);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeople", new { id = People.Id }, People);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<People>> DeletePeople(int id)
        {
            var People = await _context.People.FindAsync(id);
            if (People == null)
            {
                return NotFound();
            }

            _context.People.Remove(People);
            await _context.SaveChangesAsync();

            return People;
        }

        private bool PeopleExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }

    }
}
