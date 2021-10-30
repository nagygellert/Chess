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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ChatService(IChatRepository chatRepository, IUserRepository userRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChatMessageDTO>> GetAsync()
        {
            var messages = await _chatRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ChatMessageDTO>>(messages);
        }

        public async Task<ChatMessageDTO> GetAsync(Guid id) 
        {
            var msg = await _chatRepository.GetOneAsync(id);
            return _mapper.Map<ChatMessageDTO>(msg);
        }

        public async Task<ChatMessageDTO> InsertAsync(ChatMessageDTO chatMessage)
        {
            var mappedMessage = _mapper.Map<ChatMessage>(chatMessage);
            var user = await _userRepository.GetRegisteredUserById(chatMessage.User.Id);
            if (user == null)
            {
                var tempUser = await _userRepository.GetTemporaryUser(chatMessage.User.Id);
                mappedMessage.User = tempUser;
            }
            else
            {
                mappedMessage.User = user;
            }
            var inserted = await _chatRepository.InsertOneAsync(mappedMessage);
            return _mapper.Map<ChatMessageDTO>(inserted);
        }

        public async Task RemoveAsync(Guid id) =>
            await _chatRepository.RemoveOneAsync(id);
    }
}
