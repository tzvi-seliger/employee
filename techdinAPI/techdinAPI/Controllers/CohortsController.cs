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
    public class CohortsController : ControllerBase
    {
        private readonly techdinContext _context;

        public CohortsController(techdinContext context)
        {
            _context = context;
        }

        // GET: api/Cohorts
        [HttpGet]
        public IEnumerable<Cohort> GetCohort()
        {
            return _context.Cohort;
        }

        // GET: api/Cohorts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCohort([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cohort = await _context.Cohort.FindAsync(id);

            if (cohort == null)
            {
                return NotFound();
            }

            return Ok(cohort);
        }

        // PUT: api/Cohorts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCohort([FromRoute] int id, [FromBody] Cohort cohort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cohort.CohortId)
            {
                return BadRequest();
            }

            _context.Entry(cohort).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CohortExists(id))
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

        // POST: api/Cohorts
        [HttpPost]
        public async Task<IActionResult> PostCohort([FromBody] Cohort cohort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cohort.Add(cohort);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCohort", new { id = cohort.CohortId }, cohort);
        }

        // DELETE: api/Cohorts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCohort([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cohort = await _context.Cohort.FindAsync(id);
            if (cohort == null)
            {
                return NotFound();
            }

            _context.Cohort.Remove(cohort);
            await _context.SaveChangesAsync();

            return Ok(cohort);
        }

        private bool CohortExists(int id)
        {
            return _context.Cohort.Any(e => e.CohortId == id);
        }
    }
}