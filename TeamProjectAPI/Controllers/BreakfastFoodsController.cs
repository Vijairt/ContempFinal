using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamProjectAPI.Data;
using TeamProjectAPI.Models;

namespace TeamProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreakfastFoodsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BreakfastFoodsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BreakfastFoods?id=0  (null or 0 returns first 5)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreakfastFood>>> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
                return Ok(await _context.BreakfastFoods.Take(5).ToListAsync());

            var food = await _context.BreakfastFoods.FindAsync(id);
            if (food == null) return NotFound();
            return Ok(food);
        }

        // POST: api/BreakfastFoods
        [HttpPost]
        public async Task<ActionResult<BreakfastFood>> Create(BreakfastFood breakfastFood)
        {
            _context.BreakfastFoods.Add(breakfastFood);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = breakfastFood.Id }, breakfastFood);
        }

        // PUT: api/BreakfastFoods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BreakfastFood breakfastFood)
        {
            if (id != breakfastFood.Id) return BadRequest();
            var existing = await _context.BreakfastFoods.FindAsync(id);
            if (existing == null) return NotFound();
            _context.Entry(existing).CurrentValues.SetValues(breakfastFood);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/BreakfastFoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await _context.BreakfastFoods.FindAsync(id);
            if (food == null) return NotFound();
            _context.BreakfastFoods.Remove(food);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
