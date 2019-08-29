using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechdinAPI.Models;

namespace TechdinAPI.Controllers
{
    public class LoginModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private SignInManager<User> _signManager;
        private UserManager<User> _userManager;

        public LoginController(UserManager<User> userManager, SignInManager<User> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(model.UserName,
                   model.Password, true, false);

                if (result.Succeeded)
                {
                    return Ok();
                }
                return Unauthorized();
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return BadRequest();
        }
    }
}