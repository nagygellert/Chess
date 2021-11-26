using Chess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Interfaces
{
    public interface IChatRepository
    {
        Task<IEnumerable<ChatMessage>> GetMessagesForLobby(string lobbyName);

        Task DeleteMessagesForLobby(string lobbyName);

        Task<ChatMessage> InsertOneAsync(ChatMessage msg);
    }
}
