using Chess.IdentityServer.Models;
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.IdentityServer.Quickstart.Account
{
    [AllowAnonymous]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SignUpController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup([FromBody] SignUp accountDetails)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = accountDetails.Username
            };
            IdentityResult result = await _userManager.CreateAsync(applicationUser, accountDetails.Password);

            if (result.Succeeded)
                return NoContent();
            else
                return Problem(result.Errors.FirstOrDefault()?.Description, statusCode: StatusCodes.Status400BadRequest);
        }
    }
}
