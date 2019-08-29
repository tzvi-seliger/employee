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
    public class BlogPostsController : ControllerBase
    {
        private readonly techdinContext _context;

        public BlogPostsController(techdinContext context)
        {
            _context = context;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return _context.BlogPosts;
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPosts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogPosts = await _context.BlogPosts.FindAsync(id);

            if (blogPosts == null)
            {
                return NotFound();
            }

            return Ok(blogPosts);
        }

        // PUT: api/BlogPosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPosts([FromRoute] int id, [FromBody] BlogPost blogPosts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blogPosts.PostId)
            {
                return BadRequest();
            }

            _context.Entry(blogPosts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostsExists(id))
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

        // POST: api/BlogPosts
        [HttpPost]
        public async Task<IActionResult> PostBlogPosts([FromBody] BlogPost blogPosts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BlogPosts.Add(blogPosts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogPosts", new { id = blogPosts.PostId }, blogPosts);
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPosts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogPosts = await _context.BlogPosts.FindAsync(id);
            if (blogPosts == null)
            {
                return NotFound();
            }

            _context.BlogPosts.Remove(blogPosts);
            await _context.SaveChangesAsync();

            return Ok(blogPosts);
        }

        private bool BlogPostsExists(int id)
        {
            return _context.BlogPosts.Any(e => e.PostId == id);
        }
    }
}