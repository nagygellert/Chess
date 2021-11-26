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
        public async Task<IActionResult> CreateLobby([FromBody] LobbyConfigDTO newLobby)
        {
            var allMsg = await _lobbyConfigService.CreateLobbyConfig(newLobby);
            return Ok(allMsg);
        }

        [HttpGet]
        public async Task<IActionResult> GetLobbies()
        {
            var allMsg = await _lobbyConfigService.GetLobbyConfigs();
            return Ok(allMsg);
        }

        [HttpGet]
        [Route("{name}/config")]
        public async Task<IActionResult> GetLobbyConfig(string name)
        {
            var config = await _lobbyConfigService.GetLobbyConfigByName(name);
            return Ok(config);
        }

        [HttpDelete]
        [Route("{name}")]
        public async Task<IActionResult> DeleteLobbyConfig(string name)
        {
            await _lobbyConfigService.DeleteLobbyConfig(name);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLobby(string name)
        {
            await _lobbyService.DeleteLobby(name);
            return NoContent();
        }
    }
}
