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
    [Route("Lobby")]
    public class LobbyController : ControllerBase
    {
        private readonly ILobbyConfigService _lobbyConfigService;

        public LobbyController(ILobbyConfigService lobbyConfigService)
        {
            _lobbyConfigService = lobbyConfigService;
        }

        [HttpPost]
        public async Task<IActionResult> GetRegisteredAccount([FromBody] LobbyConfigDTO lobbyConfig)
        {
            var lobby = await _lobbyConfigService.GetLobbyConfigByName(lobbyConfig.Name);
            return Ok(lobby);
        }

        [HttpGet]
        [Route("{lobbyName}/config")]
        public async Task<IActionResult> GetLobbyConfig(string lobbyName)
        {
            var lobby = await _lobbyConfigService.GetLobbyConfigByName(lobbyName);
            return Ok(lobby);
        }
    }
}
