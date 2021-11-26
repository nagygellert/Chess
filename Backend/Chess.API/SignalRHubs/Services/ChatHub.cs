using AutoMapper;
using Chess.API.SignalRHubs.Interfaces;
using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.API.SignalRHubs.Services
{
    public class ChatHub : Hub<IChatHub>
    {
        private const string _suffix = "Chat";
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task EnteredChat(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"{room}{_suffix}");
            var messages = await _chatService.GetRoomMessages(room);
            await Clients.Caller.SetMessages(messages);
        }

        public async Task NewMessage(ChatMessageDTO message, string room)
        {
            var insertedMsg = await _chatService.InsertAsync(message, room);
            await Clients.Group($"{room}{_suffix}").SetMessage(insertedMsg);
        }
    }
}
