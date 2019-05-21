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
    [Route("api/BrandCategories")]
    [ApiController]
    public class BrandCategoriesController : ControllerBase
    {
        private readonly Salestrackerdbcontext _context;

        public BrandCategoriesController(Salestrackerdbcontext context)
        {
            _context = context;
        }

        // GET: api/BrandCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandCategory>>> GetBrandCategory()
        {
            return await _context.BrandCategory.ToListAsync();
        }

        // GET: api/BrandCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandCategory>> GetBrandCategory(int id)
        {
            var brandCategory = await _context.BrandCategory.FindAsync(id);

            if (brandCategory == null)
            {
                return NotFound();
            }

            return brandCategory;
        }

        // PUT: api/BrandCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrandCategory(int id, BrandCategory brandCategory)
        {
            brandCategory.Id = id;
            if (id <= 0)
            {
                return BadRequest();
            }

            _context.Entry(brandCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandCategoryExists(id))
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

        // POST: api/BrandCategories
        [HttpPost]
        public async Task<ActionResult<BrandCategory>> PostBrandCategory(BrandCategory brandCategory)
        {
            _context.BrandCategory.Add(brandCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrandCategory", new { id = brandCategory.Id }, brandCategory);
        }

        // DELETE: api/BrandCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BrandCategory>> DeleteBrandCategory(int id)
        {
            var brandCategory = await _context.BrandCategory.FindAsync(id);
            if (brandCategory == null)
            {
                return NotFound();
            }

            _context.BrandCategory.Remove(brandCategory);
            await _context.SaveChangesAsync();

            return brandCategory;
        }

        private bool BrandCategoryExists(int id)
        {
            return _context.BrandCategory.Any(e => e.Id == id);
        }
    }
}
