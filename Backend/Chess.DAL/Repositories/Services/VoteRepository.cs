using Chess.DAL.Configurations.Interfaces;
using Chess.DAL.Repositories.Interfaces;
using Chess.Models.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Services
{
    public class VoteRepository : IVoteRepository
    {
        private readonly IMongoCollection<Vote> _voteCollection;

        public VoteRepository(IChessDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _voteCollection = database.GetCollection<Vote>(databaseSettings.VotesCollectionName);
        }

        public async Task<IEnumerable<Vote>> GetVotesForLobby(string lobbyId)
        {
            return await _voteCollection.Find(vote => !vote.IsDeleted && vote.LobbyId == lobbyId).ToListAsync();
        }

        public async Task<Vote> InsertVote(Vote vote)
        {
            await _voteCollection.InsertOneAsync(vote);
            return vote;
        }
    }
}
