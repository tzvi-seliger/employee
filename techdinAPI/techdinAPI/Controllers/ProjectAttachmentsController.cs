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
    public class ProjectAttachmentsController : ControllerBase
    {
        private readonly techdinContext _context;

        public ProjectAttachmentsController(techdinContext context)
        {
            _context = context;
        }

        // GET: api/ProjectAttachments
        [HttpGet]
        public IEnumerable<ProjectAttachment> GetProjectAttachments()
        {
            return _context.ProjectAttachments;
        }

        // GET: api/ProjectAttachments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectAttachments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectAttachments = await _context.ProjectAttachments.FindAsync(id);

            if (projectAttachments == null)
            {
                return NotFound();
            }

            return Ok(projectAttachments);
        }

        // PUT: api/ProjectAttachments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectAttachments([FromRoute] int id, [FromBody] ProjectAttachment projectAttachments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectAttachments.ProjAttId)
            {
                return BadRequest();
            }

            _context.Entry(projectAttachments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectAttachmentsExists(id))
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

        // POST: api/ProjectAttachments
        [HttpPost]
        public async Task<IActionResult> PostProjectAttachments([FromBody] ProjectAttachment projectAttachments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectAttachments.Add(projectAttachments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectAttachments", new { id = projectAttachments.ProjAttId }, projectAttachments);
        }

        // DELETE: api/ProjectAttachments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAttachments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectAttachments = await _context.ProjectAttachments.FindAsync(id);
            if (projectAttachments == null)
            {
                return NotFound();
            }

            _context.ProjectAttachments.Remove(projectAttachments);
            await _context.SaveChangesAsync();

            return Ok(projectAttachments);
        }

        private bool ProjectAttachmentsExists(int id)
        {
            return _context.ProjectAttachments.Any(e => e.ProjAttId == id);
        }
    }
}