using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProfileBuilder.Helpers;
using StudentProfileBuilder.Models;
using StudentProfileBuilder.Services;

namespace StudentProfileBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class UsersController : ControllerBase
    {
        private UserDAO _userDAO;
        private InvitationDAO _invitationDAO;

        public UsersController(UserDAO userDAO, InvitationDAO invitationDAO)
        {
            _userDAO = userDAO;
            _invitationDAO = invitationDAO;
        }

        /// <summary>
        /// Retrieves a list of all users from our database. Get
        /// </summary>
        /// <returns></returns>
        //GET: api/Users
        [HttpGet]
        public List<User> GetAllUsers()
        {
            List<User> allUsers = _userDAO.GetAllUsers();
            foreach(User user in allUsers)
            {
                user.UserCohort = _userDAO.GetUserCohort(user);
            }
            return allUsers;
        }

        /// <summary>
        /// Gets a users' information based on a username. Get via URI
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        // GET: api/Users/exampleUsername
        [HttpGet("{username}", Name = "GetUser")]
        public User Get(string username)
        {
            User user = _userDAO.GetUserByUsername(username);
            return user;
        }

        /// <summary>
        /// Creates a user and adds it to the database, requires a form to POST
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        // POST: api/Users
        [HttpPost]
        public string CreateUser([FromForm] User user)
        {
            string enteredPass = user.Password;
            if(!_invitationDAO.CheckCode(user.Email, user.InvitationCode))
            {
                return "Invitation Code Does not Match";
            }

            if (user != null)
            {
                if(user.HomePhone == null)
                {
                    user.HomePhone = "";
                }
                if(user.CellPhone == null)
                {
                    user.CellPhone = "";
                }
                user.Salt = PasswordHasher.Salter();
                user.Password = PasswordHasher.Hasher(user.Password, user.Salt);
                user = _userDAO.CreateUser(user);
                if(user == null)
                {
                    return "User already exists";
                }
                if (!_invitationDAO.DeleteInvite(user.Email))
                {
                    return "Failed to Delete user invitation";
                }
                FilesHelper.CreateUserDirectory(user.Username);
                var option = new CookieOptions();
                option.Expires = DateTime.Now.AddMinutes(10);
                option.IsEssential = true;

                Response.Cookies.Delete("userName");
                Response.Cookies.Append("userName", user.Username, option);
                return "User created successfully";
            }

            return "Form not filled out properly";
        }

        /// <summary>
        /// Checks if a users' login information matches what is in the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        // GET: api/Users/username/password
        [HttpGet("{username}/{password}", Name = "Login")]
        public bool LoginUser(string username, string password)
        {
            User user = _userDAO.GetUserByUsername(username);
            if (user != null)
            {
                string hashedPassword = PasswordHasher.Hasher(password, user.Salt);
                return hashedPassword == user.Password;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Will update user info based on fields entered. Temporarily based on username, will be based on session soon
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/Users/exampleUsername
        [HttpPut("{username}")]
        public User Put(string username, [FromForm] User updatedUser)
        {
            User oldUser = _userDAO.GetUserByUsername(username);
            if(oldUser == null)
            {
                return null;
            }
            oldUser.Header = updatedUser.Header;
            oldUser.FirstName = updatedUser.FirstName;
            oldUser.LastName = updatedUser.LastName;
            oldUser.Description = updatedUser.Description;
            _userDAO.UpdateUser(oldUser);
            return oldUser;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
