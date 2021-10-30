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
        Task<IEnumerable<PieceLocationDTO>> GetTableState(Guid lobbyId);

        Task<Guid> CreateLobby();

        Task InsertMove(Guid lobbyId, MoveDTO moveId);

        Task DeleteLobby(Guid lobbyId);
    }
}
