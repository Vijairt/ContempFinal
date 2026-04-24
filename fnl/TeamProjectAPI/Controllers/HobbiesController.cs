using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamProjectAPI.Data;
using TeamProjectAPI.Models;

namespace TeamProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HobbiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HobbiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Hobbies?id=0
        // READ operation - accepts an optional id from the query string.
        // If no id is provided or id is 0, it returns the first 5 hobbies from the database.
        // If a valid id is provided, it looks up that specific hobby.
        // Returns 404 Not Found if the hobby does not exist.
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Hobby>>> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
                return Ok(await _context.Hobbies.Take(5).ToListAsync());

            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null) return NotFound();
            return Ok(hobby);
        }

        // POST: api/Hobbies
        // CREATE operation - accepts a Hobby object in the request body as JSON.
        // Adds the new hobby to the database and saves the changes.
        // Returns 201 Created with the newly created hobby and its location.
        [HttpPost]
        public async Task<ActionResult<Hobby>> Create(Hobby hobby)
        {
            _context.Hobbies.Add(hobby);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = hobby.Id }, hobby);
        }

        // PUT: api/Hobbies/5
        // UPDATE operation - accepts the id in the URL and the updated Hobby object in the request body.
        // First checks that the id in the URL matches the id in the body to prevent mismatch errors.
        // Finds the existing record in the database and updates its values.
        // Returns 404 Not Found if no matching record exists, or 204 No Content on success.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Hobby hobby)
        {
            if (id != hobby.Id) return BadRequest();
            var existing = await _context.Hobbies.FindAsync(id);
            if (existing == null) return NotFound();
            _context.Entry(existing).CurrentValues.SetValues(hobby);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Hobbies/5
        // DELETE operation - accepts the id in the URL.
        // Looks up the hobby in the database by id.
        // Returns 404 Not Found if the record does not exist.
        // Removes the record from the database and returns 204 No Content on success.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null) return NotFound();
            _context.Hobbies.Remove(hobby);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
