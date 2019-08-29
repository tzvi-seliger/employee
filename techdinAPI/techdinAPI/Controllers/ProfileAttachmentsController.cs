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
    public class ProfileAttachmentsController : ControllerBase
    {
        private readonly techdinContext _context;

        public ProfileAttachmentsController(techdinContext context)
        {
            _context = context;
        }

        // GET: api/ProfileAttachments
        [HttpGet]
        public IEnumerable<ProfileAttachment> GetProfileAttachments()
        {
            return _context.ProfileAttachments;
        }

        // GET: api/ProfileAttachments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileAttachments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profileAttachments = await _context.ProfileAttachments.FindAsync(id);

            if (profileAttachments == null)
            {
                return NotFound();
            }

            return Ok(profileAttachments);
        }

        // PUT: api/ProfileAttachments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfileAttachments([FromRoute] int id, [FromBody] ProfileAttachment profileAttachments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profileAttachments.ProfAttId)
            {
                return BadRequest();
            }

            _context.Entry(profileAttachments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileAttachmentsExists(id))
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

        // POST: api/ProfileAttachments
        [HttpPost]
        public async Task<IActionResult> PostProfileAttachments([FromBody] ProfileAttachment profileAttachments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProfileAttachments.Add(profileAttachments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfileAttachments", new { id = profileAttachments.ProfAttId }, profileAttachments);
        }

        // DELETE: api/ProfileAttachments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileAttachments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profileAttachments = await _context.ProfileAttachments.FindAsync(id);
            if (profileAttachments == null)
            {
                return NotFound();
            }

            _context.ProfileAttachments.Remove(profileAttachments);
            await _context.SaveChangesAsync();

            return Ok(profileAttachments);
        }

        private bool ProfileAttachmentsExists(int id)
        {
            return _context.ProfileAttachments.Any(e => e.ProfAttId == id);
        }
    }
}