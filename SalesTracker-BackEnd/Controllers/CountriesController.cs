﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Domain.Contracts.UnitOfWork;
using SalesTracker.Domain.Entities;
using SalesTracker.Infrastructure.Data.Context;

namespace SalesTracker.WebAPI.Controllers
{
    [Route("api/Countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly Salestrackerdbcontext _context;

        public CountriesController(Salestrackerdbcontext context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Countries>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Countries>> GetCountries([FromRoute]int id)
        {
            var countries = await _context.Countries.FindAsync(id);

            if (countries == null)
            {
                return NotFound();
            }

            return countries;
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountries([FromRoute]int id, [FromBody]Countries countries)
        {
            countries.Id = id;
            if (id <= 0)
            {
                return BadRequest();
            }

            _context.Entry(countries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountriesExists(id))
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

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<Countries>> PostCountries([FromBody]Countries countries)
        {
            _context.Countries.Add(countries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountries", new { id = countries.Id }, countries);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Countries>> DeleteCountries([FromRoute]int id)
        {
            var countries = await _context.Countries.FindAsync(id);
            if (countries == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(countries);
            await _context.SaveChangesAsync();

            return countries;
        }

        private bool CountriesExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
