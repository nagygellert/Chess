using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allMsg = await _chatService.GetAsync();
            return Ok(allMsg);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ChatMessageDTO message)
        {
            var msg = await _chatService.InsertAsync(message);
            return Ok(msg);
        }
    }
}
