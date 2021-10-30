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
    public class MoveService : IMoveService
    {
        private readonly IMoveRepository _moveRepository;
        private readonly IMapper _mapper;

        public MoveService(IMoveRepository moveRepository, IMapper mapper)
        {
            _moveRepository = moveRepository;
            _mapper = mapper;
        }

        public async Task<MoveDTO> GetMove(Guid id)
        {
            return _mapper.Map<MoveDTO>(await _moveRepository.GetMove(id));
        }

        public async Task<MoveDTO> InsertMove(MoveDTO move)
        {
            var insertedMove = await _moveRepository.InsertMove(_mapper.Map<Move>(move));
            return _mapper.Map<MoveDTO>(insertedMove);
        }
    }
}
