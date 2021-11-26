using Chess.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.Interfaces
{
    public interface ILobbyService
    {
        Task<IEnumerable<MoveDTO>> GetTableMoves(string lobbyName);

        Task<IEnumerable<TileDTO>> CreateLobby(string lobbyName);

        IEnumerable<TileDTO> GenerateDefaultBoard();

        Task InsertMove(string lobbyName, MoveDTO moveId);

        Task DeleteLobby(string lobbyName);
    }
}
