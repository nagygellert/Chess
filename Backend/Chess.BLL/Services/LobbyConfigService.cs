using AutoMapper;
using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Chess.DAL.Repositories.Interfaces;
using Chess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.Services
{
    public class LobbyConfigService : ILobbyConfigService
    {
        private readonly ILobbyConfigRepository _lobbyConfigRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly Random _random;

        public LobbyConfigService(ILobbyConfigRepository lobbyConfigRepository, IMapper mapper, Random random, IUserRepository userRepository)
        {
            _lobbyConfigRepository = lobbyConfigRepository;
            _mapper = mapper;
            _random = random;
            _userRepository = userRepository;
        }

        public async Task<LobbyConfigDTO> GetLobbyConfigByCode(int roomCode)
        {
            var efConfig = await _lobbyConfigRepository.GetLobbyConfigByCode(roomCode);
            return _mapper.Map<LobbyConfigDTO>(efConfig);
        }

        public async Task AddPlayer(int roomCode, UserDTO player)
        {
            var user = await _userRepository.GetTemporaryUser(player.Id);
            var lobby = await _lobbyConfigRepository.GetLobbyConfigByCode(roomCode);
            user.Lobby = lobby;
            var createdLobby = await _lobbyConfigRepository.CreateLobbyConfig(lobby);
        }

        public async Task<LobbyConfigDTO> CreateLobbyConfig(UserDTO lobbyOwner)
        {
            var existingCodes = new HashSet<int>(await _lobbyConfigRepository.GetExistingRoomCodes());
            var availableValues = Enumerable.Range(1000, 9000).Where(code => !existingCodes.Contains(code));
            int index = _random.Next(1000, 9000 - existingCodes.Count);
            var owner = await _userRepository.GetRegisteredUserById(lobbyOwner.Id);
            var lobby = new LobbyConfig { Owner = owner, RoomCode = availableValues.ElementAt(index)};
            var createdLobby = await _lobbyConfigRepository.CreateLobbyConfig(lobby);
            return _mapper.Map<LobbyConfigDTO>(createdLobby);
        }

        public async Task DeleteLobbyConfig(Guid id)
        {
            await _lobbyConfigRepository.DeleteLobbyConfig(id);
        }
    }
}
