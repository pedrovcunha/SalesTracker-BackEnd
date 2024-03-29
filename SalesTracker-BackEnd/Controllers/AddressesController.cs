﻿using System;
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
    [Route("api/Addresses")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly Salestrackerdbcontext _context;

        public AddressesController(Salestrackerdbcontext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<IEnumerable<Addresses>>> GetAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<Addresses>> GetAddresses([FromRoute]int id)
        {
            var addresses = await _context.Addresses.FindAsync(id);

            if (addresses == null)
            {
                return NotFound();
            }

            return addresses;
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddresses([FromRoute]int id, [FromBody] Addresses addresses)
        {
            addresses.Id = id;

            if (id <= 0)
            {
                return BadRequest();
            }

            _context.Entry(addresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressesExists(id))
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

        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult<Addresses>> PostAddresses([FromBody]Addresses addresses)
        {
            _context.Addresses.Add(addresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddresses", new { id = addresses.Id }, addresses);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Addresses>> DeleteAddresses([FromRoute]int id)
        {
            var addresses = await _context.Addresses.FindAsync(id);
            if (addresses == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(addresses);
            await _context.SaveChangesAsync();

            return addresses;
        }

        private bool AddressesExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
