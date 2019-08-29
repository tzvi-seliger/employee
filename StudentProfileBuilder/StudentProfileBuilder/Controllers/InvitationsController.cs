using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProfileBuilder.Services;
using StudentProfileBuilder.Models;
using StudentProfileBuilder.Helpers;

namespace StudentProfileBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class InvitationsController : ControllerBase
    {
        private UserDAO _userDAO;
        private InvitationDAO _invitationDAO;

        public InvitationsController(UserDAO userDAO, InvitationDAO invitationDAO)
        {
            _userDAO = userDAO;
            _invitationDAO = invitationDAO;
        }

        // POST: api/Invitations
        [HttpPost]
        public Invitation CreateInvitation([FromHeader] string email)
        {
            Invitation inv = _invitationDAO.CreateCode(email);
            //InvitationsHelper.SendEmail(inv);
            return inv;
        }

        // PUT: api/Invitations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
