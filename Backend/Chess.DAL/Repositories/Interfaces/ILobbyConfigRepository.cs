using Chess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Interfaces
{
    public interface ILobbyConfigRepository
    {
        Task<LobbyConfig> GetLobbyConfigByName(string name);

        Task<IEnumerable<LobbyConfig>> GetLobbyConfigs();

        Task<LobbyConfig> GetLobbyConfigById(Guid Id);

        Task<IEnumerable<string>> GetExistingRoomNames();

        Task<int> GetCurrentRound(string lobbyName);

        Task<LobbyConfig> CreateLobbyConfig(LobbyConfig config);

        Task UpdateLobbyConfig(string lobbyName, LobbyConfig config);

        Task DeleteLobbyConfig(string roomName);
    }
}
