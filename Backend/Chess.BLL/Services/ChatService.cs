using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Chess.Models.Entities;
using Chess.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace Chess.BLL.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILobbyRepository _lobbyRepository;
        private readonly IMapper _mapper;

        public ChatService(IChatRepository chatRepository, IUserRepository userRepository, IMapper mapper, ILobbyRepository lobbyRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _lobbyRepository = lobbyRepository;
        }

        public async Task<IEnumerable<ChatMessageDTO>> GetRoomMessages(string roomName)
        {
            var messages = await _chatRepository.GetMessagesForLobby(roomName);
            return _mapper.Map<IEnumerable<ChatMessageDTO>>(messages);
        }

        public async Task<ChatMessageDTO> InsertAsync(ChatMessageDTO chatMessage, string roomName)
        {
            var mappedMessage = _mapper.Map<ChatMessage>(chatMessage);
            mappedMessage.User = await _userRepository.GetUser(chatMessage.User.Id);
            mappedMessage.Lobby = await _lobbyRepository.GetLobbyByName(roomName);
            var inserted = await _chatRepository.InsertOneAsync(mappedMessage);
            return _mapper.Map<ChatMessageDTO>(inserted);
        }
    }
}
