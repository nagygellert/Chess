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

        [AllowAnonymous]
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userService.GetAllUser();
            return Ok(user);
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

        [AllowAnonymous]
        [HttpPost]
        [Route("temporary/{id}")]
        public async Task<IActionResult> GetTemporaryAccount(Guid id)
        {
            var user = await _userService.GetTemporaryUser(id);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("temporary")]
        public async Task<IActionResult> CreateTemporaryAccount([FromQuery] int roomCode, TemporaryUserDTO temporaryUser)
        {
            temporaryUser.LobbyCode = roomCode;
            var createdUser = await _userService.CreateTemporaryUser(temporaryUser);
            return Ok(createdUser);
        }
    }
}
