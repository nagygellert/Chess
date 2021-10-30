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
        Task<IEnumerable<ChatMessage>> GetAllAsync();

        Task<IEnumerable<ChatMessage>> GetMessagesForLobby(Guid lobbyId);

        Task<ChatMessage> GetOneAsync(Guid id);

        Task<ChatMessage> InsertOneAsync(ChatMessage msg);

        Task RemoveOneAsync(Guid id);
    }
}
