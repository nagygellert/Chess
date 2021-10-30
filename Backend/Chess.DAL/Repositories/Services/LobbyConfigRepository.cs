using Chess.DAL.Contexts;
using Chess.DAL.Repositories.Interfaces;
using Chess.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Services
{
    public class LobbyConfigRepository : ILobbyConfigRepository
    {
        private readonly ChessDbContext _chessDbContext;

        public LobbyConfigRepository(ChessDbContext chessDbContext)
        {
            _chessDbContext = chessDbContext;
        }

        public async Task<LobbyConfig> GetLobbyConfigByCode(int roomCode)
            => await _chessDbContext.LobbyConfigs.FirstOrDefaultAsync(config => config.RoomCode == roomCode);

        public async Task<IEnumerable<int>> GetExistingRoomCodes()
        {
            return await _chessDbContext.LobbyConfigs.Select(config => config.RoomCode).ToListAsync();
        }

        public async Task<LobbyConfig> CreateLobbyConfig(LobbyConfig config)
        {
            await _chessDbContext.LobbyConfigs.AddAsync(config);
            await _chessDbContext.SaveChangesAsync();
            return config;
        }

        public async Task DeleteLobbyConfig(Guid id)
        {
            var lobbyToDelete = await _chessDbContext.LobbyConfigs.FindAsync(id);
            _chessDbContext.Remove(lobbyToDelete);
        }
    }
}
