using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
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

        public LobbyController(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var allMsg = await _lobbyService.CreateLobby();
            return Ok(allMsg);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var msg = await _lobbyService.GetTableState(id);
            return Ok(msg);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _lobbyService.DeleteLobby(id);
            return NoContent();
        }

        [HttpPost]
        [Route("/move")]
        public async Task<IActionResult> PostMove(string id, MoveDTO move)
        {
            await _lobbyService.InsertMove(id, move);
            return NoContent();
        }
    }
}
