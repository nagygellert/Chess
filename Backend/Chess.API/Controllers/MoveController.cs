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
    public class MoveController : ControllerBase
    {
        private readonly IMoveService _moveService;

        public MoveController(IMoveService moveService)
        {
            _moveService = moveService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var msg = await _moveService.GetMove(id);
            return Ok(msg);
        }
    }
}
