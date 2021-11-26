using Chess.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.API.SignalRHubs.Interfaces
{
    public interface ILobbyListHub
    {
        Task SetLobbies(IEnumerable<LobbyConfigDTO> lobbies);
    }
}
