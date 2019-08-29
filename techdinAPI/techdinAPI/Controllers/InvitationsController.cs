using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechdinAPI.Helpers;
using TechdinAPI.Models;

namespace TechdinAPI.Controllers
{
    public class InvitationModel
    {
        [Required, MaxLength(256)]
        public string email;
        [Required]
        public AcctType type;
    }
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    //[EnableCors("CorsPolicy")]
    public class InvitationsController : ControllerBase
    {
        private readonly techdinContext _context;

        public InvitationsController(techdinContext context)
        {
            _context = context;
        }

        /// <summary>
        /// returns a list of email addresses with active invites
        /// </summary>
        // GET: api/Invitations
        [HttpGet]
        public IEnumerable<string> GetInvitations()
        {
            return _context.Invitations.Select(i => i.Email);
        }

        /// <summary>
        /// sends an invite code to the email.
        /// if a code already exists for the email it deletes it first.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        // POST: api/Invitations
        [HttpPost]
        public async Task<IActionResult> PostInvitations([FromBody] InvitationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invite = _context.Invitations
                            .Where(i => i.Email == model.email)
                            .FirstOrDefault();

            if (invite != null)
            {
                _context.Invitations.Remove(invite);
                _context.SaveChanges();
            }

            invite = new Invitation() { Email = model.email, Type = model.type, InvKey = InvitationsHelper.CodeGenerator() };
            _context.Invitations.Add(invite);
            await _context.SaveChangesAsync();
            InvitationsHelper.SendEmail(invite);
            return Ok();
        }

        /// <summary>
        /// deletes the invitation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Invitations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvitations([FromRoute] string id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var invite = await _context.Invitations.FindAsync(id);
            if (invite == null)
            {
                return NotFound();
            }

            _context.Invitations.Remove(invite);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool InvitationsExists(string email)
        {
            return _context.Invitations.Any(e => e.Email == email);
        }

        //// GET: api/Invitations/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetInvitations([FromRoute] int id)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    var invitations = await _context.Invitations.FindAsync(id);

        //    if (invitations == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(invitations);
        //}

        //// PUT: api/Invitations/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutInvitations([FromRoute] int id, [FromBody] Invitations invitations)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != invitations.InvID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(invitations).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!InvitationsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


    }
}
