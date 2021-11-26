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
                .ForPath(dest => dest.Column, opt => opt.MapFrom(src => src.From.Column))
                .ForPath(dest => dest.Row, opt => opt.MapFrom(src => src.From.Row))
                .ForPath(dest => dest.NewColumn, opt => opt.MapFrom(src => src.To.Column))
                .ForPath(dest => dest.NewRow, opt => opt.MapFrom(src => src.To.Row))
                .ReverseMap();

            CreateMap<VoteDTO, Vote>()
                .ForPath(dest => dest.Row, opt => opt.MapFrom(src => src.Move.From.Row))
                .ForPath(dest => dest.Column, opt => opt.MapFrom(src => src.Move.From.Column))
                .ForPath(dest => dest.NewRow, opt => opt.MapFrom(src => src.Move.To.Row))
                .ForPath(dest => dest.NewColumn, opt => opt.MapFrom(src => src.Move.To.Column))
                .ForPath(dest => dest.Round, opt => opt.MapFrom(src => src.Round))
                .ReverseMap();

            CreateMap<Vote, Move>()
                .ReverseMap();


            /*CreateMap<TileDTO, PieceLocation>()
                .ForPath(dest => dest.Color, opt => opt.MapFrom(src => src.ChessPiece.Side))
                .ForMember(dest => dest.Column, opt => opt.MapFrom(src => src.Column))
                .ForMember(dest => dest.Row, opt => opt.MapFrom(src => src.Row))
                .ForPath(dest => dest.Type, opt => opt.MapFrom(src => src.ChessPiece.Type))
                .ReverseMap();*/



            CreateMap<UserDTO, UserBase>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Name));

            CreateMap<UserBase, UserDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => AccountType.Temporary));

            CreateMap<UserDTO, RegisteredUser>()
                .ForMember(dest => dest.UserProfileId, opt => opt.MapFrom(src => src.Sub))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<RegisteredUser, UserDTO>()
                .ForMember(dest => dest.Sub, opt => opt.MapFrom(src => src.UserProfileId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => AccountType.Registered));

            CreateMap<LobbyConfig, LobbyConfigDTO>()
                .ForMember(dest => dest.WhiteTeamPlayers, opt => opt.MapFrom(src => src.Players.Where(p => p.Side == Models.Enums.Side.White)))
                .ForMember(dest => dest.BlackTeamPlayers, opt => opt.MapFrom(src => src.Players.Where(p => p.Side == Models.Enums.Side.Black)));

            CreateMap<LobbyConfigDTO, LobbyConfig>();
        }
    }
}
