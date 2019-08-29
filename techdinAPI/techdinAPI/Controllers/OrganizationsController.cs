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
    public class OrganizationsController : ControllerBase
    {
        private readonly techdinContext _context;

        public OrganizationsController(techdinContext context)
        {
            _context = context;
        }

        // GET: api/Organizations
        [HttpGet]
        public IEnumerable<Organization> GetOrganizations()
        {
            return _context.Organizations;
        }

        // GET: api/Organizations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizations = await _context.Organizations.FindAsync(id);

            if (organizations == null)
            {
                return NotFound();
            }

            return Ok(organizations);
        }

        // PUT: api/Organizations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizations([FromRoute] int id, [FromBody] Organization organizations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organizations.OrganizationId)
            {
                return BadRequest();
            }

            _context.Entry(organizations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationsExists(id))
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

        // POST: api/Organizations
        [HttpPost]
        public async Task<IActionResult> PostOrganizations([FromBody] Organization organizations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Organizations.Add(organizations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizations", new { id = organizations.OrganizationId }, organizations);
        }

        // DELETE: api/Organizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizations = await _context.Organizations.FindAsync(id);
            if (organizations == null)
            {
                return NotFound();
            }

            _context.Organizations.Remove(organizations);
            await _context.SaveChangesAsync();

            return Ok(organizations);
        }

        private bool OrganizationsExists(int id)
        {
            return _context.Organizations.Any(e => e.OrganizationId == id);
        }
    }
}