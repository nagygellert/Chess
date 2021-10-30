using Chess.DAL.Contexts;
using Chess.DAL.Repositories.Interfaces;
using Chess.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Services
{
    public class VoteRepository : IVoteRepository
    {
        private readonly ChessDbContext _chessDbContext;

        public VoteRepository(ChessDbContext chessDbContext)
        {
            _chessDbContext = chessDbContext;
        }

        public async Task<IEnumerable<Vote>> GetVotesForLobby(Guid lobbyId)
            => await _chessDbContext.Votes.Where(vote => vote.Lobby.Id == lobbyId).ToListAsync();
        
        public async Task<Vote> InsertVote(Vote vote)
        {
            await _chessDbContext.Votes.AddAsync(vote);
            return vote;
        }
    }
}
