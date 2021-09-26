using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Chess.DAL.Models;
using Chess.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<IEnumerable<ChatMessageDTO>> GetAsync() =>
            (await _chatRepository.GetAllAsync()).Select(msg => new ChatMessageDTO { Id = msg.Id, Text = msg.Text, TimeStamp = msg.TimeStamp });

        public async Task<ChatMessageDTO> GetAsync(string id) 
        {
            var msg = await _chatRepository.GetOneAsync(id);
            return new ChatMessageDTO { Id = msg.Id, Text = msg.Text, TimeStamp = msg.TimeStamp };
        }

        public async Task<ChatMessageDTO> InsertAsync(string text)
        {
            var inserted = await _chatRepository.InsertOneAsync(new ChatMessage {Text = text, TimeStamp = DateTime.Now });
            return new ChatMessageDTO { Id = inserted.Id, Text = inserted.Text, TimeStamp = inserted.TimeStamp };
        }

        public async Task RemoveAsync(string id) =>
            await _chatRepository.RemoveOneAsync(id);
        
    }
}
