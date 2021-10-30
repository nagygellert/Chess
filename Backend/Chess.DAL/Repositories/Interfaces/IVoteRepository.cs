using Chess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Interfaces
{
    public interface IVoteRepository
    {
        Task<IEnumerable<Vote>> GetVotesForLobby(Guid lobbyId);

        Task<Vote> InsertVote(Vote vote); 
    }
}
