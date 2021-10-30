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
            CreateMap<ChatMessageDTO, ChatMessage>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.TimeStamp))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<MoveDTO, Move>()
                //.ForMember(x => x.MovedTo, opt => opt.MapFrom(src => src.To))
                //.ForMember(x => x.CurrentLocation, opt => opt.MapFrom(src => src.From))
                .ReverseMap();

            CreateMap<VoteDTO, Vote>()
                .ReverseMap();

            CreateMap<TableSpaceDTO, TableSpace>()
                .ReverseMap();

            CreateMap<PieceLocationDTO, PieceLocation>()
                .ReverseMap();

            CreateMap<UserDTO, UserBase>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<UserDTO, RegisteredUser>()
                .ForMember(dest => dest.UserProfileId, opt => opt.MapFrom(src => src.Sub))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<TemporaryUserDTO, UserBase>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<LobbyConfig, LobbyConfigDTO>()
                .ForMember(dest => dest.WhiteTeamPlayers, opt => opt.MapFrom(src => src.Players.Where(p => p.Side == Models.Enums.Side.White)))
                .ForMember(dest => dest.BlackTeamPlayers, opt => opt.MapFrom(src => src.Players.Where(p => p.Side == Models.Enums.Side.Black)));
        }
    }
}
