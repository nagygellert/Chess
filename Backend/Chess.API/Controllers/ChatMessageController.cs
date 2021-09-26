using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatMessageController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatMessageController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allMsg = await _chatService.GetAsync();
            return Ok(allMsg);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var msg = await _chatService.GetAsync(id);
            return Ok(msg);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string text)
        {
            var msg = await _chatService.InsertAsync(text);
            return Ok(msg);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
             await _chatService.RemoveAsync(id);
            return NoContent();
        }
    }
}
