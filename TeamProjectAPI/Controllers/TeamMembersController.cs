using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamProjectAPI.Data;
using TeamProjectAPI.Models;

namespace TeamProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamMembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamMembersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TeamMembers?id=0
        // READ operation - accepts an optional id from the query string.
        // If no id is provided or id is 0, it returns the first 5 team members from the database.
        // If a valid id is provided, it looks up that specific team member.
        // Returns 404 Not Found if the team member does not exist.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMember>>> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
                return Ok(await _context.TeamMembers.Take(5).ToListAsync());

            var member = await _context.TeamMembers.FindAsync(id);
            if (member == null) return NotFound();
            return Ok(member);
        }

        // POST: api/TeamMembers
        // CREATE operation - accepts a TeamMember object in the request body as JSON.
        // Adds the new team member to the database and saves the changes.
        // Returns 201 Created with the newly created team member and its location.
        [HttpPost]
        public async Task<ActionResult<TeamMember>> Create(TeamMember teamMember)
        {
            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = teamMember.Id }, teamMember);
        }

        // PUT: api/TeamMembers/5
        // UPDATE operation - accepts the id in the URL and the updated TeamMember object in the request body.
        // First checks that the id in the URL matches the id in the body to prevent mismatch errors.
        // Finds the existing record in the database and updates its values.
        // Returns 404 Not Found if no matching record exists, or 204 No Content on success.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TeamMember teamMember)
        {
            if (id != teamMember.Id) return BadRequest();
            var existing = await _context.TeamMembers.FindAsync(id);
            if (existing == null) return NotFound();
            _context.Entry(existing).CurrentValues.SetValues(teamMember);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/TeamMembers/5
        // DELETE operation - accepts the id in the URL.
        // Looks up the team member in the database by id.
        // Returns 404 Not Found if the record does not exist.
        // Removes the record from the database and returns 204 No Content on success.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _context.TeamMembers.FindAsync(id);
            if (member == null) return NotFound();
            _context.TeamMembers.Remove(member);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
