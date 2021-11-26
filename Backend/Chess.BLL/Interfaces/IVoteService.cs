using Chess.BLL.DTOs;
using Chess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.Interfaces
{
    public interface IVoteService
    {
        Task<Move> SummarizeVotes(string lobbyName);

        Task<VoteDTO> InsertVote(VoteDTO vote);

        Task<IEnumerable<VoteDTO>> GetVotesForLobby(string lobbyName, int round);
    }
}
