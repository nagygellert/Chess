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
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;

        public LobbyConfigService(ILobbyConfigRepository lobbyConfigRepository, IMapper mapper, IUserRepository userRepository, IChatRepository chatRepository)
        {
            _lobbyConfigRepository = lobbyConfigRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _chatRepository = chatRepository;
        }

        public async Task<LobbyConfigDTO> GetLobbyConfigByName(string name)
        {
            var efConfig = await _lobbyConfigRepository.GetLobbyConfigByName(name);
            return _mapper.Map<LobbyConfigDTO>(efConfig);
        }

        public async Task<IEnumerable<LobbyConfigDTO>> GetLobbyConfigs()
        {
            return _mapper.Map<IEnumerable<LobbyConfigDTO>>(await _lobbyConfigRepository.GetLobbyConfigs());
        }

        public async Task<LobbyConfigDTO> AddPlayerToLobby(UserDTO player, string name)
        {
            var user = await _userRepository.GetUser(player.Id);
            user.Side ??= Models.Enums.Side.White;
            var lobby = await _lobbyConfigRepository.GetLobbyConfigByName(name);
            user.LobbyConfigId = lobby.Id;
            await _userRepository.UpdateUser(user);
            return _mapper.Map<LobbyConfigDTO>(lobby);
        }

        public async Task RemovePlayerFromLobby(Guid playerId)
        {
            var user = await _userRepository.GetUser(playerId);
            //user.Side = null;
            user.LobbyConfigId = null;
            await _userRepository.UpdateUser(user);
        }

        public async Task<LobbyConfigDTO> CreateLobbyConfig(LobbyConfigDTO lobbyConfig)
        {
            var existingNames = await _lobbyConfigRepository.GetExistingRoomNames();
            if (existingNames.Contains(lobbyConfig.Name))
                return null;
            var lobby = _mapper.Map<LobbyConfig>(lobbyConfig);
            var owner = await _userRepository.GetRegisteredUserById(lobbyConfig.Owner.Id);
            lobby.Owner = owner;
            var createdLobby = await _lobbyConfigRepository.CreateLobbyConfig(lobby);
            owner.LobbyConfigId = createdLobby.Id;
            await _userRepository.UpdateUser(owner);
            return _mapper.Map<LobbyConfigDTO>(createdLobby);
        }

        public async Task DeleteLobbyConfig(string name)
        {
            await _chatRepository.DeleteMessagesForLobby(name);
            await _lobbyConfigRepository.DeleteLobbyConfig(name);
        }

        public async Task IncrementTurn(string lobbyName)
        {
            var lobby = await _lobbyConfigRepository.GetLobbyConfigByName(lobbyName);
            lobby.Round++;
            await _lobbyConfigRepository.UpdateLobbyConfig(lobbyName, lobby);
        }
    }
}
