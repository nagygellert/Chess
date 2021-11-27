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

        Task CreateLobby(string lobbyName);
    }
}
