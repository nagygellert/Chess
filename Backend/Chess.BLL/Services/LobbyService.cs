using AutoMapper;
using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Chess.DAL.Repositories.Interfaces;
using Chess.Models.Entities;
using Chess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.Services
{
    public class LobbyService : ILobbyService
    {
        private readonly ILobbyRepository _lobbyRepository;
        private readonly ILobbyConfigRepository _lobbyConfigRepository;
        private readonly IMapper _mapper;

        public LobbyService(ILobbyRepository lobbyRepository, IMapper mapper, ILobbyConfigRepository lobbyConfigRepository)
        {
            _lobbyRepository = lobbyRepository;
            _mapper = mapper;
            _lobbyConfigRepository = lobbyConfigRepository;
        }

        public async Task<IEnumerable<MoveDTO>> GetTableMoves(string lobbyName)
        {
            var state = await _lobbyRepository.GetTableState(lobbyName);
            return _mapper.Map<IEnumerable<MoveDTO>>(state);
        }

        public async Task CreateLobby(string lobbyName)
        {
            var lobbyConfig = await _lobbyConfigRepository.GetLobbyConfigByName(lobbyName);
            lobbyConfig.GameStarted = true;
            await _lobbyConfigRepository.UpdateLobbyConfig(lobbyName, lobbyConfig);
            await _lobbyRepository.InsertLobby(new Lobby { LobbyConfig = lobbyConfig });
        }
    }
}
