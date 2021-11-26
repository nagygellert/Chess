using Chess.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.Interfaces
{
    public interface IChatService
    {
        Task<IEnumerable<ChatMessageDTO>> GetRoomMessages(string roomName);

        Task<ChatMessageDTO> InsertAsync(ChatMessageDTO chatMessage, string roomName);
    }
}
