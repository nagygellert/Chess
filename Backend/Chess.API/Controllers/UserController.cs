using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("registered/{id}")]
        public async Task<IActionResult> GetRegisteredAccount(Guid id)
        {
            var user = await _userService.GetRegisteredUser(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("registered")]
        public async Task<IActionResult> CreateRegisteredAccount(UserDTO user)
        {
            var createdUser = await _userService.CreateRegisteredUser(user);
            return Ok(createdUser);
        }

        [HttpPost]
        [Route("temporary/{id}")]
        public async Task<IActionResult> GetTemporaryAccount(Guid id)
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("swap/{id}")]
        public async Task<IActionResult> SwapSides(Guid id)
        {
            var user = await _userService.SwapSides(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("temporary")]
        public async Task<IActionResult> CreateTemporaryAccount(UserDTO temporaryUser)
        {
            var createdUser = await _userService.CreateTemporaryUser(temporaryUser);
            return Ok(createdUser);
        }
    }
}
