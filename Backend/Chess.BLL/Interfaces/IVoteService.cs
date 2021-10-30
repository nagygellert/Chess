using Chess.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.Interfaces
{
    public interface IVoteService
    {
        Task<IEnumerable<VoteDTO>> GetVotesForLobby(Guid lobbyId);

        Task<VoteDTO> InsertVote(Guid lobbyId, VoteDTO vote);
    }
}
