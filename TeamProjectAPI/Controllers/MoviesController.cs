using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamProjectAPI.Data;
using TeamProjectAPI.Models;

namespace TeamProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies?id=0
        // READ operation - accepts an optional id from the query string.
        // If no id is provided or id is 0, it returns the first 5 movies from the database.
        // If a valid id is provided, it looks up that specific movie.
        // Returns 404 Not Found if the movie does not exist.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
                return Ok(await _context.Movies.Take(5).ToListAsync());

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        // POST: api/Movies
        // CREATE operation - accepts a Movie object in the request body as JSON.
        // Adds the new movie to the database and saves the changes.
        // Returns 201 Created with the newly created movie and its location.
        [HttpPost]
        public async Task<ActionResult<Movie>> Create(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }

        // PUT: api/Movies/5
        // UPDATE operation - accepts the id in the URL and the updated Movie object in the request body.
        // First checks that the id in the URL matches the id in the body to prevent mismatch errors.
        // Finds the existing record in the database and updates its values.
        // Returns 404 Not Found if no matching record exists, or 204 No Content on success.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Movie movie)
        {
            if (id != movie.Id) return BadRequest();
            var existing = await _context.Movies.FindAsync(id);
            if (existing == null) return NotFound();
            _context.Entry(existing).CurrentValues.SetValues(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Movies/5
        // DELETE operation - accepts the id in the URL.
        // Looks up the movie in the database by id.
        // Returns 404 Not Found if the record does not exist.
        // Removes the record from the database and returns 204 No Content on success.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
