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
    [Route("[controller]")]
    public class LobbyController : ControllerBase
    {
        private readonly ILobbyService _lobbyService;
        private readonly ILobbyConfigService _lobbyConfigService;

        public LobbyController(ILobbyService lobbyService, ILobbyConfigService lobbyConfigService)
        {
            _lobbyService = lobbyService;
            _lobbyConfigService = lobbyConfigService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLobby([FromBody] UserDTO lobbyOwner)
        {
            var allMsg = await _lobbyConfigService.CreateLobbyConfig(lobbyOwner);
            return Ok(allMsg);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{roomCode}/config")]
        public async Task<IActionResult> GetLobbyConfig(int roomCode)
        {
            var config = await _lobbyConfigService.GetLobbyConfigByCode(roomCode);
            return Ok(config);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLobbyState(Guid id)
        {
            var msg = await _lobbyService.GetTableState(id);
            return Ok(msg);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLobby(Guid id)
        {
            await _lobbyService.DeleteLobby(id);
            return NoContent();
        }

        [HttpPost]
        [Route("/move")]
        public async Task<IActionResult> PostMove(Guid id, MoveDTO move)
        {
            await _lobbyService.InsertMove(id, move);
            return NoContent();
        }
    }
}
