using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentProfileBuilder.Models;
using StudentProfileBuilder.Helpers;
using StudentProfileBuilder.Services;
using Microsoft.AspNetCore.Cors;
using System.Web;

namespace StudentProfileBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CurrentUserController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private UserDAO _userDAO;
        public string AuthKey;

        public CurrentUserController(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        /// <summary>
        /// Returns the user from the current session
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public User GetUser()
        {
            var boh = Request.Cookies["userName"];
            User user = _userDAO.GetUserByUsername(boh);
            return user;
        }

        /// <summary>
        /// Checks if a users' login information matches what is in the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        // GET: api/Users/username/password
        [HttpGet("{username}/{password}", Name = "LoginUser")]
        public IActionResult UserLogin(string username, string password)
        {
            User user = _userDAO.GetUserByUsername(username);
            if (user != null)
            {
                string hashedPassword = PasswordHasher.Hasher(password, user.Salt);
                if (hashedPassword == user.Password)
                {
                    var option = new CookieOptions();
                    option.Expires = DateTime.Now.AddMinutes(10);
                    option.IsEssential = true;
                    Response.Cookies.Delete("userName");
                    Response.Cookies.Append("userName", user.Username, option);
                    if(user.AcctType == 1)
                    {
                        return Redirect("https://localhost:44358/html/admin.html");
                    }
                    else if(user.AcctType == 2)
                    {
                        return Redirect($"https://localhost:44358/html/employerprofile.html?username={user.Username}");
                    }
                    else if(user.AcctType == 3)
                    {
                        return Redirect($"https://localhost:44358/html/profile.html?username={user.Username}");
                    }
                }
                return NotFound();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("userName");
            return Redirect("https://localhost:44358/landing.html");
        }
    }
}
