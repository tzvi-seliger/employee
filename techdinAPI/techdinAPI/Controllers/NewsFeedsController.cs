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
    public class NewsFeedsController : ControllerBase
    {
        private readonly techdinContext _context;

        public NewsFeedsController(techdinContext context)
        {
            _context = context;
        }

        // GET: api/NewsFeeds
        [HttpGet]
        public IEnumerable<NewsFeed> GetNewsFeed()
        {
            return _context.NewsFeed;
        }

        // GET: api/NewsFeeds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsFeed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newsFeed = await _context.NewsFeed.FindAsync(id);

            if (newsFeed == null)
            {
                return NotFound();
            }

            return Ok(newsFeed);
        }

        // PUT: api/NewsFeeds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsFeed([FromRoute] int id, [FromBody] NewsFeed newsFeed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsFeed.ChangeId)
            {
                return BadRequest();
            }

            _context.Entry(newsFeed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsFeedExists(id))
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

        // POST: api/NewsFeeds
        [HttpPost]
        public async Task<IActionResult> PostNewsFeed([FromBody] NewsFeed newsFeed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.NewsFeed.Add(newsFeed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsFeed", new { id = newsFeed.ChangeId }, newsFeed);
        }

        // DELETE: api/NewsFeeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsFeed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newsFeed = await _context.NewsFeed.FindAsync(id);
            if (newsFeed == null)
            {
                return NotFound();
            }

            _context.NewsFeed.Remove(newsFeed);
            await _context.SaveChangesAsync();

            return Ok(newsFeed);
        }

        private bool NewsFeedExists(int id)
        {
            return _context.NewsFeed.Any(e => e.ChangeId == id);
        }
    }
}