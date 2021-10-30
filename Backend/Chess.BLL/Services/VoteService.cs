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
        private readonly IMapper _mapper;

        public VoteService(IVoteRepository voteRepository, IMapper mapper)
        {
            _voteRepository = voteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VoteDTO>> GetVotesForLobby(Guid lobbyId)
        {
            var votes = await _voteRepository.GetVotesForLobby(lobbyId);
            return _mapper.Map<IEnumerable<VoteDTO>>(votes);
        }

        public async Task<VoteDTO> InsertVote(Guid lobbyId, VoteDTO vote)
        {
            var insertedVote = await _voteRepository.InsertVote(_mapper.Map<Vote>(vote));
            return _mapper.Map<VoteDTO>(insertedVote);
        }
    }
}
