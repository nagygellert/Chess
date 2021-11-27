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
        Task<IEnumerable<Move>> GetTableState(string lobbyName);

        Task<Lobby> GetLobbyByName(string lobbyName);

        Task<Lobby> InsertLobby(Lobby lobby);

        Task DeleteLobby(string lobbyName);
    }
}
