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

        // GET: api/Hobbies?id=0  (null or 0 returns first 5)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hobby>>> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
                return Ok(await _context.Hobbies.Take(5).ToListAsync());

            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null) return NotFound();
            return Ok(hobby);
        }

        // POST: api/Hobbies
        [HttpPost]
        public async Task<ActionResult<Hobby>> Create(Hobby hobby)
        {
            _context.Hobbies.Add(hobby);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = hobby.Id }, hobby);
        }

        // PUT: api/Hobbies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Hobby hobby)
        {
            if (id != hobby.Id) return BadRequest();
            _context.Entry(hobby).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Hobbies.Any(e => e.Id == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE: api/Hobbies/5
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
