using Chess.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.API.SignalRHubs.Interfaces
{
    public interface ILobbyHub
    {
        Task PlayerJoined(UserDTO player);

        Task PlayerLeft(UserDTO player);

        Task OwnerLeft();

        Task SetLobby(LobbyConfigDTO lobby);

        Task SetBoard(IEnumerable<TileDTO> board);

        Task SetMoves(IEnumerable<MoveDTO> moves);

        Task SetVotes(IEnumerable<VoteDTO> votes);

        Task GameStarted();
    }
}
