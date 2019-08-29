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
    public class OrganizationUsersController : ControllerBase
    {
        private readonly techdinContext _context;

        public OrganizationUsersController(techdinContext context)
        {
            _context = context;
        }

        // GET: api/OrganizationUsers
        [HttpGet]
        public IEnumerable<OrganizationUser> GetOrganizationUser()
        {
            return _context.OrganizationUser;
        }

        // GET: api/OrganizationUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizationUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizationUser = await _context.OrganizationUser.FindAsync(id);

            if (organizationUser == null)
            {
                return NotFound();
            }

            return Ok(organizationUser);
        }

        // PUT: api/OrganizationUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationUser([FromRoute] int id, [FromBody] OrganizationUser organizationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organizationUser.OrganizationId)
            {
                return BadRequest();
            }

            _context.Entry(organizationUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationUserExists(id))
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

        // POST: api/OrganizationUsers
        [HttpPost]
        public async Task<IActionResult> PostOrganizationUser([FromBody] OrganizationUser organizationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrganizationUser.Add(organizationUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrganizationUserExists(organizationUser.OrganizationId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrganizationUser", new { id = organizationUser.OrganizationId }, organizationUser);
        }

        // DELETE: api/OrganizationUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizationUser = await _context.OrganizationUser.FindAsync(id);
            if (organizationUser == null)
            {
                return NotFound();
            }

            _context.OrganizationUser.Remove(organizationUser);
            await _context.SaveChangesAsync();

            return Ok(organizationUser);
        }

        private bool OrganizationUserExists(int id)
        {
            return _context.OrganizationUser.Any(e => e.OrganizationId == id);
        }
    }
}