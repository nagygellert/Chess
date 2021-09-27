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
        Task<IEnumerable<PieceLocation>> GetTableState(string lobbyId);

        Task<Lobby> InsertLobby(Lobby lobby);

        Task<Lobby> InsertMoveReference(string lobbyId, string moveId);

        Task<Lobby> UpdateLobby(string lobbyId, Lobby lobby);

        Task DeleteLobby(string lobbyId);
    }
}
