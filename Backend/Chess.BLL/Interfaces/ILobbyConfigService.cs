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
        Task<LobbyConfigDTO> GetLobbyConfigByCode(int roomCode);

        Task<LobbyConfigDTO> CreateLobbyConfig(UserDTO owner);

        Task DeleteLobbyConfig(Guid id);
    }
}
