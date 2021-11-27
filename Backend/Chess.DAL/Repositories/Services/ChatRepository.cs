using Chess.Models.Entities;
using Chess.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Chess.DAL.Repositories.Services
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChessDbContext _chessDbContext;

        public ChatRepository(ChessDbContext chessDbContext)
        {
            _chessDbContext = chessDbContext;
        }

        public async Task<IEnumerable<ChatMessage>> GetMessagesForLobby(string lobbyName)  
            => await _chessDbContext.ChatMessages.Where(msg => msg.Lobby.LobbyConfig.Name == lobbyName).Include(msg => msg.User).ToListAsync();
        
        public async Task<ChatMessage> InsertOneAsync(ChatMessage msg)
        {
            await _chessDbContext.ChatMessages.AddAsync(msg);
            await _chessDbContext.SaveChangesAsync();
            return msg;
        }

        public async Task DeleteMessagesForLobby(string lobbyName)
        {
            var messagesToDelete = await _chessDbContext.ChatMessages.Where(msg => msg.Lobby.LobbyConfig.Name == lobbyName).ToListAsync();
            _chessDbContext.ChatMessages.RemoveRange(messagesToDelete);
            await _chessDbContext.SaveChangesAsync();
        }
    }
}
