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
    public class LobbyService : ILobbyService
    {
        private readonly ILobbyRepository _lobbyRepository;
        private readonly IMoveRepository _moveRepository;
        private readonly IMapper _mapper;

        public LobbyService(ILobbyRepository lobbyRepository, IMoveRepository moveRepository, IMapper mapper)
        {
            _lobbyRepository = lobbyRepository;
            _moveRepository = moveRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PieceLocationDTO>> GetTableState(string lobbyId)
        {
            var state = await _lobbyRepository.GetTableState(lobbyId);
            return _mapper.Map<IEnumerable<PieceLocationDTO>>(state);
        }

        public async Task<string> CreateLobby()
        {
            var insertedLobby = await _lobbyRepository.InsertLobby(new Lobby { });
            return insertedLobby.Id;
        }

        public async Task InsertMove(string lobbyId, MoveDTO move)
        {
            var insertedMove = await _moveRepository.InsertMove(_mapper.Map<Move>(move));
            await _lobbyRepository.InsertMoveReference(lobbyId, insertedMove.Id);
        }

        public async Task DeleteLobby(string lobbyId)
        {
            await _lobbyRepository.DeleteLobby(lobbyId);
        }
    }
}
