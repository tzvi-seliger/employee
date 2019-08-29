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
    public class UserInterestsController : ControllerBase
    {
        private readonly techdinContext _context;

        public UserInterestsController(techdinContext context)
        {
            _context = context;
        }

        // GET: api/UserInterests
        [HttpGet]
        public IEnumerable<UserInterests> GetUserInterests()
        {
            return _context.UserInterests;
        }

        // GET: api/UserInterests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInterests([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UserInterests = await _context.UserInterests.FindAsync(id);

            if (UserInterests == null)
            {
                return NotFound();
            }

            return Ok(UserInterests);
        }

        // PUT: api/UserInterests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInterests([FromRoute] string id, [FromBody] UserInterests UserInterests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != UserInterests.UserName)
            {
                return BadRequest();
            }

            _context.Entry(UserInterests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInterestsExists(id))
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

        // POST: api/UserInterests
        [HttpPost]
        public async Task<IActionResult> PostUserInterests([FromBody] UserInterests UserInterests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserInterests.Add(UserInterests);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserInterestsExists(UserInterests.UserName))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserInterests", new { id = UserInterests.UserName }, UserInterests);
        }

        // DELETE: api/UserInterests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInterests([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UserInterests = await _context.UserInterests.FindAsync(id);
            if (UserInterests == null)
            {
                return NotFound();
            }

            _context.UserInterests.Remove(UserInterests);
            await _context.SaveChangesAsync();

            return Ok(UserInterests);
        }

        private bool UserInterestsExists(string id)
        {
            return _context.UserInterests.Any(e => e.UserName == id);
        }
    }
}