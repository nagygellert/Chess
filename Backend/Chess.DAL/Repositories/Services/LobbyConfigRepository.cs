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
    public class LobbyConfigRepository : ILobbyConfigRepository
    {
        private IMongoCollection<LobbyConfig> _lobbyConfigCollection;

        public LobbyConfigRepository(IChessDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _lobbyConfigCollection = database.GetCollection<LobbyConfig>(databaseSettings.LobbyConfigCollectionName);
        }

        public async Task<LobbyConfig> GetLobbyConfig(string id)
        {
            return await _lobbyConfigCollection.Find(cfg => cfg.Id == id).FirstOrDefaultAsync();
        }

        public async Task<LobbyConfig> InsertOne(LobbyConfig config)
        {
            await _lobbyConfigCollection.InsertOneAsync(config);
            return config;
        }

        public async Task DeleteLobbyConfig(string id)
        {
            await _lobbyConfigCollection.DeleteOneAsync(cfg => cfg.Id == id);
        }
    }
}
