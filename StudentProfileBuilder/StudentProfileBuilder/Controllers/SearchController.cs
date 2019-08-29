using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProfileBuilder.Models;
using StudentProfileBuilder.Services;

namespace StudentProfileBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class SearchController : ControllerBase
    {
        private UserDAO _userDAO;

        public SearchController(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        // GET: api/Search/
        [HttpGet]
        public List<User> SearchUsers([FromHeader]string season = "", [FromHeader]string location = "", [FromHeader]string skillName = "")
        {
            if (season == null)
            {
                season = "";
            }
            if (location == null)
            {
                location = "";
            }
            if (skillName == null)
            {
                skillName = "";
            }

            List<User> users = _userDAO.GetUsersBySearch("%" + season + "%", "%" + location + "%", "%" + skillName + "%");
            for (int i = 0; i < users.Count; i++)
            {
                users[i] = _userDAO.GetUserByUsername(users[i].Username);
            }
            return users;
        }

        // POST: api/Search
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Search/5
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
