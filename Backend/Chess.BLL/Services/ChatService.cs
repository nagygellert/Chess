using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Chess.Models.Entities;
using Chess.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Chess.BLL.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;

        public ChatService(IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChatMessageDTO>> GetAsync()
        {
            var messages = await _chatRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ChatMessageDTO>>(messages);
        }

        public async Task<ChatMessageDTO> GetAsync(string id) 
        {
            var msg = await _chatRepository.GetOneAsync(id);
            return _mapper.Map<ChatMessageDTO>(msg);
        }

        public async Task<ChatMessageDTO> InsertAsync(ChatMessageDTO chatMessage)
        {
            var inserted = await _chatRepository.InsertOneAsync(_mapper.Map<ChatMessage>(chatMessage));
            return _mapper.Map<ChatMessageDTO>(inserted);
        }

        public async Task RemoveAsync(string id) =>
            await _chatRepository.RemoveOneAsync(id);
        
    }
}
