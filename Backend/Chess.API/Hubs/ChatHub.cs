using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task NewMessage(ChatMessageDTO chatMessage)
        {
            await _chatService.InsertAsync(chatMessage);
            await Clients.All.SendAsync("messageReceived");
        }
    }
}
