using Chess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Interfaces
{
    public interface ILobbyRepository
    {
        Task<IEnumerable<PieceLocation>> GetTableState(Guid lobbyId);

        Task<Lobby> InsertLobby(Lobby lobby);

        Task<Lobby> InsertMoveReference(Guid lobbyId, Guid moveId);

        Lobby UpdateLobby(Lobby lobby);

        Task DeleteLobby(Guid lobbyId);
    }
}
