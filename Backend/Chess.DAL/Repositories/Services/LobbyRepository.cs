using Chess.DAL.Configurations.Interfaces;
using Chess.DAL.Repositories.Interfaces;
using Chess.Models.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Services
{
    public class LobbyRepository : ILobbyRepository
    {
        private readonly IMongoCollection<Lobby> _lobbyCollection;

        public LobbyRepository(IChessDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _lobbyCollection = database.GetCollection<Lobby>(databaseSettings.LobbiesCollectionName);
        }

        public async Task<IEnumerable<PieceLocation>> GetTableState(string lobbyId)
        {
            return (await _lobbyCollection.Find(lobby => lobby.Id == lobbyId).FirstOrDefaultAsync()).Tiles;
        }

        public async Task<Lobby> InsertLobby(Lobby lobby)
        {
            await _lobbyCollection.InsertOneAsync(lobby);
            return lobby;
        }

        public async Task<Lobby> InsertMoveReference(string lobbyId, string moveId)
        {
            var lobby = await _lobbyCollection.Find(lobby => lobby.Id == lobbyId).FirstOrDefaultAsync();
            var updatedMoves = lobby.MoveIds.Append(moveId);
            var update = Builders<Lobby>.Update.Set(nameof(lobby.MoveIds), updatedMoves);
            await _lobbyCollection.UpdateOneAsync(lobby => lobby.Id == lobbyId, update);
            return lobby;
        }

        public async Task<Lobby> UpdateLobby(string lobbyId, Lobby lobby)
        {
            await _lobbyCollection.ReplaceOneAsync(lobby => lobby.Id == lobbyId, lobby);
            return lobby;
        }

        public async Task DeleteLobby(string lobbyId)
        {
            await _lobbyCollection.DeleteOneAsync(lobby => lobby.Id == lobbyId);
        }
    }
}
