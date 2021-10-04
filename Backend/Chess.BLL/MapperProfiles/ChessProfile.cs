using AutoMapper;
using Chess.BLL.DTOs;
using Chess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.MapperProfiles
{
    public class ChessProfile : Profile
    {
        public ChessProfile()
        {
            CreateMap<ChatMessage, ChatMessageDTO>()
                .ForMember(x => x.TimeStamp, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<MoveDTO, Move>()
                .ForMember(x => x.MovedTo, opt => opt.MapFrom(src => src.To))
                .ForMember(x => x.CurrentLocation, opt => opt.MapFrom(src => src.From))
                .ReverseMap();
            CreateMap<VoteDTO, Vote>()
                .ReverseMap();
            CreateMap<TableSpaceDTO, TableSpace>()
                .ReverseMap();
            CreateMap<PieceLocationDTO, PieceLocation>()
                .ReverseMap();
        }
    }
}
