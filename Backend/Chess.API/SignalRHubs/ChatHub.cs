using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.API.SignalRHubs
{
    public class ChatHub : Hub<IChatHub>
    {
        public async Task NewMessage()
        {
            await Clients.All.SetMessages(null);
        }
    }
}
