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
    public class MoveRepository : IMoveRepository
    {
        private readonly IMongoCollection<Move> _moveCollection;

        public MoveRepository(IChessDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _moveCollection = database.GetCollection<Move>(databaseSettings.MovesCollectionName);
        }

        public async Task<Move> GetMove(string id)
        {
           return await _moveCollection.Find(move => !move.IsDeleted && move.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Move> InsertMove(Move move)
        {
            await _moveCollection.InsertOneAsync(move);
            return move;
        }
    }
}
