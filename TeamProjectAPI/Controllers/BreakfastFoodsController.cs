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

        // GET: api/BreakfastFoods?id=0
        // READ operation - accepts an optional id from the query string.
        // If no id is provided or id is 0, it returns the first 5 breakfast foods from the database.
        // If a valid id is provided, it looks up that specific breakfast food.
        // Returns 404 Not Found if the breakfast food does not exist.
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
        // CREATE operation - accepts a BreakfastFood object in the request body as JSON.
        // Adds the new breakfast food to the database and saves the changes.
        // Returns 201 Created with the newly created breakfast food and its location.
        [HttpPost]
        public async Task<ActionResult<BreakfastFood>> Create(BreakfastFood breakfastFood)
        {
            _context.BreakfastFoods.Add(breakfastFood);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = breakfastFood.Id }, breakfastFood);
        }

        // PUT: api/BreakfastFoods/5
        // UPDATE operation - accepts the id in the URL and the updated BreakfastFood object in the request body.
        // First checks that the id in the URL matches the id in the body to prevent mismatch errors.
        // Finds the existing record in the database and updates its values.
        // Returns 404 Not Found if no matching record exists, or 204 No Content on success.
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
        // DELETE operation - accepts the id in the URL.
        // Looks up the breakfast food in the database by id.
        // Returns 404 Not Found if the record does not exist.
        // Removes the record from the database and returns 204 No Content on success.
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
