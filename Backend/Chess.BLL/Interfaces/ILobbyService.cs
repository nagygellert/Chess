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
        Task<IEnumerable<PieceLocationDTO>> GetTableState(string lobbyId);

        Task<string> CreateLobby();

        Task InsertMove(string lobbyId, MoveDTO moveId);

        Task DeleteLobby(string lobbyId);
    }
}
