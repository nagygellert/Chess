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

        public async Task<IEnumerable<LobbyConfig>> GetLobbyConfigs()
        {
            return await _chessDbContext.LobbyConfigs.Where(config => config.GameStarted == false).Include(lobby => lobby.Owner).ToListAsync();
        }

        public async Task<LobbyConfig> GetLobbyConfigByName(string name)
        {
            return await _chessDbContext.LobbyConfigs.Include(config => config.Owner)
                                    .Include(config => config.Players).FirstOrDefaultAsync(config => config.Name == name);
        }

        public async Task<IEnumerable<string>> GetExistingRoomNames()
        {
            return await _chessDbContext.LobbyConfigs.Select(config => config.Name).ToListAsync();
        }

        public async Task<LobbyConfig> CreateLobbyConfig(LobbyConfig config)
        {
            await _chessDbContext.LobbyConfigs.AddAsync(config);
            await _chessDbContext.SaveChangesAsync();
            return config;
        }

        public async Task<LobbyConfig> GetLobbyConfigById(Guid Id)
        {
            return await _chessDbContext.LobbyConfigs.FindAsync(Id);
        }

        public async Task DeleteLobbyConfig(string roomName)
        {
            var lobbyToDelete = await _chessDbContext.LobbyConfigs.Where(room => room.Name == roomName).FirstOrDefaultAsync();
            _chessDbContext.LobbyConfigs.Remove(lobbyToDelete);
            await _chessDbContext.SaveChangesAsync();
        }

        public async Task UpdateLobbyConfig(string lobbyName, LobbyConfig config)
        {
            var configToUpdate = await _chessDbContext.LobbyConfigs.FirstOrDefaultAsync(config => config.Name == lobbyName);
            configToUpdate = config;
            _chessDbContext.LobbyConfigs.Update(configToUpdate);
            await _chessDbContext.SaveChangesAsync();
        }

        public async Task<int> GetCurrentRound(string lobbyName)
        {
            return (await _chessDbContext.LobbyConfigs.Select(config => new { config.Name, config.Round }).FirstOrDefaultAsync(config => config.Name == lobbyName)).Round;
        }
    }
}
