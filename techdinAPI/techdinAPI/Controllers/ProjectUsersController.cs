using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechdinAPI.Models;

namespace TechdinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectUsersController : ControllerBase
    {
        private readonly techdinContext _context;

        public ProjectUsersController(techdinContext context)
        {
            _context = context;
        }

        // GET: api/ProjectUsers
        [HttpGet]
        public IEnumerable<ProjectUser> GetProjectUser()
        {
            return _context.ProjectUser;
        }

        // GET: api/ProjectUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectUser = await _context.ProjectUser.FindAsync(id);

            if (projectUser == null)
            {
                return NotFound();
            }

            return Ok(projectUser);
        }

        // PUT: api/ProjectUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectUser([FromRoute] int id, [FromBody] ProjectUser projectUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectUser.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(projectUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectUserExists(id))
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

        // POST: api/ProjectUsers
        [HttpPost]
        public async Task<IActionResult> PostProjectUser([FromBody] ProjectUser projectUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectUser.Add(projectUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectUserExists(projectUser.ProjectId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjectUser", new { id = projectUser.ProjectId }, projectUser);
        }

        // DELETE: api/ProjectUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectUser = await _context.ProjectUser.FindAsync(id);
            if (projectUser == null)
            {
                return NotFound();
            }

            _context.ProjectUser.Remove(projectUser);
            await _context.SaveChangesAsync();

            return Ok(projectUser);
        }

        private bool ProjectUserExists(int id)
        {
            return _context.ProjectUser.Any(e => e.ProjectId == id);
        }
    }
}