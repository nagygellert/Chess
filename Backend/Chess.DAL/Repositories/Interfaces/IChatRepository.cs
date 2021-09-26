using Chess.DAL.Models;
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

        Task<ChatMessage> GetOneAsync(string id);

        Task<ChatMessage> InsertOneAsync(ChatMessage msg);

        Task RemoveOneAsync(string id);
    }
}
