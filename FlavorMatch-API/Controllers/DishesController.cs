using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlavorMatch.Shared.Models;

namespace FlavorMatch_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly FlavorMatchDbContext _context;

        public DishesController(FlavorMatchDbContext context)
        {
            _context = context;
        }

        // POST: api/Dishes
        [HttpPost("CreateDish")]
        public async Task<ActionResult<Dishes>> PostDishes(Dishes dishes)
        {
            _context.Dishes.Add(dishes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDishes", new { id = dishes.Id }, dishes);
        }

        // GET: api/Dishes
        [HttpGet("GetDishes")]
        public async Task<ActionResult<IEnumerable<Dishes>>> GetDishes()
        {
            return await _context.Dishes.ToListAsync();
        }

        // GET: api/Dishes/5
        [HttpGet("GetDishById")]
        public async Task<ActionResult<Dishes>> GetDishes(int id)
        {
            var dishes = await _context.Dishes.FindAsync(id);

            if (dishes == null)
            {
                return NotFound();
            }

            return dishes;
        }

        // PUT: api/Dishes/5
        [HttpPut("UpdateDish")]
        public async Task<IActionResult> PutDishes(int id, Dishes dishes)
        {
            if (id != dishes.Id)
            {
                return BadRequest();
            }

            _context.Entry(dishes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishesExists(id))
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

        // DELETE: api/Dishes/5
        [HttpDelete("DeleteDish")]
        public async Task<IActionResult> DeleteDishes(int id)
        {
            var dishes = await _context.Dishes.FindAsync(id);
            if (dishes == null)
            {
                return NotFound();
            }

            _context.Dishes.Remove(dishes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishesExists(int id)
        {
            return _context.Dishes.Any(e => e.Id == id);
        }
    }
}
