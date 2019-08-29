using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProfileBuilder.Services;
using StudentProfileBuilder.Models;
using StudentProfileBuilder.Helpers;
using System.IO;
using System.Web;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;

namespace StudentProfileBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class FilesController : ControllerBase
    {
        private UserDAO _userDAO;

        public FilesController(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        /// <summary>
        /// Creates a file on our local server
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        // POST: api/Files
        [HttpPost]
        public IActionResult CreateFile([FromForm] List<IFormFile> files)
        {
            string username = Request.Cookies["userName"];
            try
            {
                string filePath = FilesHelper.PlaceFileInDirectory(files[0], username);
                if (filePath.Contains("img"))
                {
                    _userDAO.UpdateImagePath(filePath, username);
                    return Redirect($"https://localhost:44358/html/profile.html?username={username}");
                }
                else if (filePath.Contains("resume"))
                {
                    _userDAO.UpdateResumePath(filePath, username);
                    return Redirect($"https://localhost:44358/html/profile.html?username={username}");
                }
                return Redirect($"https://localhost:44358/html/profile.html?username={username}");
            }
            catch
            {
                return Redirect($"https://localhost:44358/html/profile.html?username={username}");
            }
        }

        // PUT: api/Files/5
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
