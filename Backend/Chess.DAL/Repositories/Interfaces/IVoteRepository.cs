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
        Task<IEnumerable<Vote>> GetVotesForLobby(string lobbyName, int round);

        Task<Vote> GetVoteForUser(Guid userId);

        Task<Vote> InsertVote(Vote vote);

        Task<Vote> UpdateVote(Guid userId, Vote vote);

        Task DeleteVote(Guid id);
    }
}
