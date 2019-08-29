using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechdinAPI.Models;

namespace TechdinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly techdinContext _context;

        public SearchController(techdinContext context)
        {
            _context = context;
        }

        // GET: api/Search
        //[HttpGet]
        //public IEnumerable<Users> SearchUsers([FromHeader]string season = "", [FromHeader]string location = "", [FromHeader]string skillName = "")
        //{
        //    if (season == null)
        //    {
        //        season = "";
        //    }
        //    if (location == null)
        //    {
        //        location = "";
        //    }
        //    if (skillName == null)
        //    {
        //        skillName = "";
        //    }

        //    List<Users> users = _context.Users
        //                            .Where(u => u.Cohort.
        //}

        // GET: api/Search/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
