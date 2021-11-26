using Chess.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.API.SignalRHubs.Interfaces
{
    public interface IChatHub
    {
        Task SetMessages(IEnumerable<ChatMessageDTO> chatMessages);

        Task SetMessage(ChatMessageDTO chatMessage);
    }
}
