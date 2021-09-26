using Chess.DAL.Configurations.Interfaces;
using Chess.DAL.Models;
using Chess.DAL.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Services
{
    public class ChatRepository : IChatRepository
    {
        private readonly IMongoCollection<ChatMessage> _chatMessages;

        public ChatRepository(IChessDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _chatMessages = database.GetCollection<ChatMessage>(databaseSettings.ChatMessagesCollectionName);
        }

        public async Task<IEnumerable<ChatMessage>> GetAllAsync() =>
            await _chatMessages.Find(_ => true).ToListAsync();

        public async Task<ChatMessage> GetOneAsync(string id) =>
            await _chatMessages.Find(msg => msg.Id == id).FirstOrDefaultAsync();
        

        public async Task<ChatMessage> InsertOneAsync(ChatMessage msg)
        {
            await _chatMessages.InsertOneAsync(msg);
            return msg;
        }

        public Task RemoveOneAsync(string id) =>
            _chatMessages.DeleteOneAsync(msg => msg.Id == id);
    }
}
