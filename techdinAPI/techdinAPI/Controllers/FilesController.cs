using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechdinAPI.Helpers;
using TechdinAPI.Models;

namespace TechdinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly techdinContext _context;

        public FilesController(techdinContext context)
        {
            _context = context;
        }

        // GET: api/Files
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        /// <summary>
        /// Creates a file on our local server
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        // POST: api/Files
        [HttpPost]
        public IActionResult CreateFile([FromForm] List<IFormFile> files, [FromForm] string username)
        {
            var user = _context.Users.Where(u => u.UserName == username).FirstOrDefault();
            if (user == null)
                return NotFound();
            try
            {
                string filePath = FilesHelper.PlaceFileInDirectory(files[0], username);
                if (filePath.Contains("img"))
                {
                    user.ImagePath = filePath;
                    _context.SaveChanges();
                }
                else if (filePath.Contains("resume"))
                {
                    user.ResumePath = filePath;
                    _context.SaveChanges();
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //// POST: api/Files
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Files/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
