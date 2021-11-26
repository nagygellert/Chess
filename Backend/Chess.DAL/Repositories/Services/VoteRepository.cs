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

        public async Task DeleteVote(Guid id)
        {
            var vote = await _chessDbContext.Votes.FindAsync(id);
            _chessDbContext.Votes.Remove(vote);
            await _chessDbContext.SaveChangesAsync();
        }

        public async Task<Vote> GetVoteForUser(Guid userId)
        {
            return await _chessDbContext.Votes.FirstOrDefaultAsync(vote => vote.User.Id == userId);
        }

        public async Task<IEnumerable<Vote>> GetVotesForLobby(string lobbyName, int round)
        {
            return await _chessDbContext.Votes.Where(vote => vote.Lobby.LobbyConfig.Name == lobbyName && vote.Round == round).Include(vote => vote.User).ToListAsync();
        }
            
        
        public async Task<Vote> InsertVote(Vote vote)
        {
            await _chessDbContext.Votes.AddAsync(vote);
            await _chessDbContext.SaveChangesAsync();
            return vote;
        }

        public async Task<Vote> UpdateVote(Guid userId, Vote vote)
        {
            var userVote = await _chessDbContext.Votes.FirstOrDefaultAsync(vote => vote.User.Id == userId);
            userVote = vote;
            await _chessDbContext.SaveChangesAsync();
            return vote;
        }
    }
}
