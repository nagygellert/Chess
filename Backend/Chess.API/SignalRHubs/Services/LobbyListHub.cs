using AutoMapper;
using Chess.API.SignalRHubs.Interfaces;
using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Chess.DAL.Repositories.Interfaces;
using Chess.Models.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.API.SignalRHubs.Services
{
    public class LobbyListHub : Hub<ILobbyListHub>
    {
        private const string LobbyGroup = "LobbySearchGroup";
        private const string _suffix = "Lobby";
        private readonly ILobbyConfigService _lobbyConfigService;
        private readonly ILobbyConfigRepository _lobbyConfigRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LobbyListHub(ILobbyConfigService lobbyConfigService, IUserRepository userRepository, ILobbyConfigRepository lobbyConfigRepository, IMapper mapper)
        {
            _lobbyConfigService = lobbyConfigService;
            _userRepository = userRepository;
            _lobbyConfigRepository = lobbyConfigRepository;
            _mapper = mapper;
        }

        public async Task EnterLobbySearch()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, LobbyGroup);
            var lobbies = await _lobbyConfigService.GetLobbyConfigs();
            await Clients.Caller.SetLobbies(lobbies);
        }

        public async Task LobbyCreated(LobbyConfigDTO newLobby)
        {
            await _lobbyConfigService.CreateLobbyConfig(newLobby);
            var lobbies = await _lobbyConfigService.GetLobbyConfigs();
            await Clients.Group(LobbyGroup).SetLobbies(lobbies);
        }

        public async Task UpdateLobbies()
        {
            var lobbies = await _lobbyConfigService.GetLobbyConfigs();
            await Clients.Group(LobbyGroup).SetLobbies(lobbies);
        }
    }
}
