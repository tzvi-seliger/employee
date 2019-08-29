using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechdinAPI.Models;

namespace TechdinAPI.Controllers
{
    public class RegisterModel
    {
        [Required, MaxLength(256)]
        public string Email { get; set; }

        [Required]
        public string InvKey { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }

    public class UpdateModel
    {
        public string Header { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ResumePath { get; set; }
        public string LinkedIn { get; set; }
        public string Repository { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private SignInManager<User> _signManager;
        private UserManager<User> _userManager;
        private readonly techdinContext _context;

        public UsersController(techdinContext context, UserManager<User> userManager, SignInManager<User> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
            _context = context;
        }
        /// <summary>
        /// Retrieves a list of all users from our database. Get
        /// </summary>
        /// <returns></returns>
        // GET: api/Projects
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.Include(u => u.Cohort);
        }

        /// <summary>
        /// Gets a users' information based on a username. Get via URI
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        // GET: api/Users/exampleUsername
        [HttpGet("{id}", Name = "GetUsers")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var user = _context.Users
                        .Where(u => u.UserName == id)
                        .FirstOrDefault();


            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

        /// <summary>
        /// Creates a user and adds it to the database, requires a form to POST
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var invite = _context.Invitations
                                .Where(i => i.Email == model.Email)
                                .FirstOrDefault();
                if (invite == null)
                    return BadRequest();

                if (invite.InvKey != model.InvKey)
                    return Unauthorized();

                var user = new User
                    {
                        Email = invite.Email,
                        UserName = model.UserName,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                    };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    result = await _userManager.AddToRoleAsync(user, invite.Type.ToString());
                    if (result.Succeeded)
                    {
                        await _signManager.SignInAsync(user, false);
                        _context.Invitations.Remove(invite);
                        _context.SaveChanges();
                        return CreatedAtRoute("GetUsers", new { id = user.UserName }, user);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return BadRequest();
        }

        /// <summary>
        /// Will update user info based on fields entered. Temporarily based on username, will be based on session soon
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/Users/exampleUsername
        [HttpPut("{username}")]
        public async Task<IActionResult> Put(string username, [FromBody] UpdateModel updatedInfo)
        {
            var user = _context.Users
                        .Where(u => u.UserName == username)
                        .FirstOrDefault();
            if (user == null)
                return BadRequest();

            user.Header = updatedInfo.Header ?? user.Header;
            user.FirstName = updatedInfo.FirstName ?? user.FirstName;
            user.LastName = updatedInfo.FirstName ?? user.FirstName;
            user.Description = updatedInfo.Description ?? user.Description;
            user.ImagePath = updatedInfo.ImagePath ?? user.ImagePath;
            user.ResumePath = updatedInfo.ResumePath ?? user.ResumePath;
            user.LinkedIn = updatedInfo.LinkedIn ?? user.LinkedIn;
            user.Repository = updatedInfo.Repository ?? user.Repository;
            user.HomePhone = updatedInfo.HomePhone ?? user.HomePhone;
            user.CellPhone = updatedInfo.CellPhone ?? user.CellPhone;
            user.Email = updatedInfo.Email ?? user.Email;

            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var user = _context.Users
                        .Where(u => u.UserName == id)
                        .FirstOrDefault();
            if (user == null)
                return NotFound();
            user.IsActive = false;
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}