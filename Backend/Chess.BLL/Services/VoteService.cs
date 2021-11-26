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
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;
        private readonly IMoveRepository _moveRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILobbyConfigRepository _lobbyConfigRepository;
        private readonly ILobbyRepository _lobbyRepository;
        private readonly IMapper _mapper;

        public VoteService(IVoteRepository voteRepository, IMapper mapper, IMoveRepository moveRepository, ILobbyConfigRepository lobbyConfigRepository,
            IUserRepository userRepository, ILobbyRepository lobbyRepository)
        {
            _voteRepository = voteRepository;
            _mapper = mapper;
            _moveRepository = moveRepository;
            _lobbyConfigRepository = lobbyConfigRepository;
            _userRepository = userRepository;
            _lobbyRepository = lobbyRepository;
        }

        public async Task<IEnumerable<VoteDTO>> GetVotesForLobby(string lobbyName, int round)
        {
            var votes = await _voteRepository.GetVotesForLobby(lobbyName, round);
            return _mapper.Map<IEnumerable<VoteDTO>>(votes);
        }

        public async Task<VoteDTO> InsertVote(VoteDTO vote)
        {
            var userVote = await _voteRepository.GetVoteForUser(vote.User.Id);
            Vote insertedVote;
            if (userVote != null)
            {
                await _voteRepository.DeleteVote(userVote.Id);
            }

            var mappedVote = _mapper.Map<Vote>(vote);
            mappedVote.User = await _userRepository.GetUser(vote.User.Id);
            mappedVote.Lobby = await _lobbyRepository.GetLobbyByName(vote.LobbyName);
            insertedVote = await _voteRepository.InsertVote(mappedVote);
            
            return _mapper.Map<VoteDTO>(insertedVote);
        }

        public async Task<Move> SummarizeVotes(string lobbyName)
        {
            var round = await _lobbyConfigRepository.GetCurrentRound(lobbyName);
            var votes = await _voteRepository.GetVotesForLobby(lobbyName, round);
            var winning = votes.GroupBy(vote => new { vote.Row, vote.Column, vote.NewColumn, vote.NewRow }).OrderByDescending(votes => votes.Count()).FirstOrDefault()?.FirstOrDefault();
            if (winning != null)
            {
                var mappedMove = _mapper.Map<Move>(winning);
                mappedMove.Lobby = await _lobbyRepository.GetLobbyByName(lobbyName);
                mappedMove.User = await _userRepository.GetUser(winning.User.Id);
                return await _moveRepository.InsertMove(_mapper.Map<Move>(winning));
            }

            return null;
        }
    }
}
