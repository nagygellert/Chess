using Chess.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.Interfaces
{
    public interface ILobbyConfigService
    {
        Task<LobbyConfigDTO> GetLobbyConfigByName(string name);

        Task<IEnumerable<LobbyConfigDTO>> GetLobbyConfigs();

        Task<LobbyConfigDTO> AddPlayerToLobby(UserDTO player, string roomName);

        Task RemovePlayerFromLobby(Guid playerId);

        Task<LobbyConfigDTO> CreateLobbyConfig(LobbyConfigDTO newLobby);

        Task IncrementTurn(string lobbyName);

        Task DeleteLobbyConfig(string name);
    }
}
