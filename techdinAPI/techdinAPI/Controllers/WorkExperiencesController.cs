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
    public class WorkExperiencesController : ControllerBase
    {
        private readonly techdinContext _context;

        public WorkExperiencesController(techdinContext context)
        {
            _context = context;
        }

        // GET: api/WorkExperiences
        [HttpGet]
        public IEnumerable<WorkExperience> GetWorkExperience()
        {
            return _context.WorkExperience;
        }

        // GET: api/WorkExperiences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkExperience([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workExperience = await _context.WorkExperience.FindAsync(id);

            if (workExperience == null)
            {
                return NotFound();
            }

            return Ok(workExperience);
        }

        // PUT: api/WorkExperiences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkExperience([FromRoute] int id, [FromBody] WorkExperience workExperience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workExperience.WorkId)
            {
                return BadRequest();
            }

            _context.Entry(workExperience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExperienceExists(id))
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

        // POST: api/WorkExperiences
        [HttpPost]
        public async Task<IActionResult> PostWorkExperience([FromBody] WorkExperience workExperience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.WorkExperience.Add(workExperience);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkExperience", new { id = workExperience.WorkId }, workExperience);
        }

        // DELETE: api/WorkExperiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkExperience([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workExperience = await _context.WorkExperience.FindAsync(id);
            if (workExperience == null)
            {
                return NotFound();
            }

            _context.WorkExperience.Remove(workExperience);
            await _context.SaveChangesAsync();

            return Ok(workExperience);
        }

        private bool WorkExperienceExists(int id)
        {
            return _context.WorkExperience.Any(e => e.WorkId == id);
        }
    }
}