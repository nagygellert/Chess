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
        private readonly IMoveRepository _moveRepository;
        private readonly IMapper _mapper;
        private static List<TableColumn> _columns = new List<TableColumn> 
        { TableColumn.A, TableColumn.B, TableColumn.C, TableColumn.D, TableColumn.E, TableColumn.F, TableColumn.G, TableColumn.H };
        private static List<int> _rows = new List<int>(Enumerable.Range(1, 8));

        public LobbyService(ILobbyRepository lobbyRepository, IMoveRepository moveRepository, IMapper mapper, ILobbyConfigRepository lobbyConfigRepository)
        {
            _lobbyRepository = lobbyRepository;
            _moveRepository = moveRepository;
            _mapper = mapper;
            _lobbyConfigRepository = lobbyConfigRepository;
        }

        public async Task<IEnumerable<MoveDTO>> GetTableMoves(string lobbyName)
        {
            var state = await _lobbyRepository.GetTableState(lobbyName);
            return _mapper.Map<IEnumerable<MoveDTO>>(state);
        }

        public async Task<IEnumerable<TileDTO>> CreateLobby(string lobbyName)
        {
            var lobbyConfig = await _lobbyConfigRepository.GetLobbyConfigByName(lobbyName);
            lobbyConfig.GameStarted = true;
            await _lobbyConfigRepository.UpdateLobbyConfig(lobbyName, lobbyConfig);
            var insertedLobby = await _lobbyRepository.InsertLobby(new Lobby { LobbyConfig = lobbyConfig });

            return _mapper.Map<IEnumerable<TileDTO>>(GenerateDefaultBoard());
        }

        public async Task InsertMove(string lobbyName, MoveDTO move)
        {
            /*var insertedMove = await _moveRepository.InsertMove(_mapper.Map<Move>(move));
            await _lobbyRepository.InsertMoveReference(lobbyId, insertedMove.Id);*/
            throw new NotImplementedException();
        }

        public async Task DeleteLobby(string lobbyName)
        {
            //await _lobbyRepository.DeleteLobby(lobbyName);
            throw new NotImplementedException();
        }

        public IEnumerable<TileDTO> GenerateDefaultBoard()
        {
            var board = new List<TileDTO>();
            board.AddRange(new List<TileDTO>
            {
                new TileDTO
                {
                    Row = 8,
                    Column = TableColumn.A,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.White,
                        Type = ChessPieceType.Rook,
                        IconUrl = "/Assets/white-rook.svg"
                    }
                },
                new TileDTO
                {
                    Row = 8,
                    Column = TableColumn.B,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.White,
                        Type = ChessPieceType.Knight,
                        IconUrl = "/Assets/white-knight.svg"
                    }
                },
                new TileDTO
                {
                    Row = 8,
                    Column = TableColumn.C,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.White,
                        Type = ChessPieceType.Bishop,
                        IconUrl = "/Assets/white-bishop.svg"
                    }
                },
                new TileDTO
                {
                    Row = 8,
                    Column = TableColumn.D,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.White,
                        Type = ChessPieceType.Queen,
                        IconUrl = "/Assets/white-queen.svg"
                    }
                },
                new TileDTO
                {
                    Row = 8,
                    Column = TableColumn.E,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.White,
                        Type = ChessPieceType.King,
                        IconUrl = "/Assets/white-king.svg"
                    }
                },
                new TileDTO
                {
                    Row = 8,
                    Column = TableColumn.F,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.White,
                        Type = ChessPieceType.Bishop,
                        IconUrl = "/Assets/white-bishop.svg"
                    }
                },
                new TileDTO
                {
                    Row = 8,
                    Column = TableColumn.G,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.White,
                        Type = ChessPieceType.Knight,
                        IconUrl = "/Assets/white-knight.svg"
                    }
                },
                new TileDTO
                {
                    Row = 8,
                    Column = TableColumn.H,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.White,
                        Type = ChessPieceType.Rook,
                        IconUrl = "/Assets/white-rook.svg"
                    }
                }
            });
            for (int i = 0; i < _columns.Count; i++)
            {
                board.Add(new TileDTO
                {
                    Row = 7,
                    Column = _columns[i],
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.White,
                        Type = ChessPieceType.Pawn,
                        IconUrl = "/Assets/white-pawn.svg"
                    }
                });
            }

            for (int i = 6; i > 2; i--)
            {
                foreach (var column in _columns)
                {
                    board.Add(new TileDTO
                    {
                        Row = i,
                        Column = column,
                        ChessPiece = null
                    });
                }
            }

            for (int i = 0; i < _columns.Count; i++)
            {
                board.Add(new TileDTO
                {
                    Row = 2,
                    Column = _columns[i],
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.Black,
                        Type = ChessPieceType.Pawn,
                        IconUrl = "/Assets/black-pawn.svg"
                    }
                });
            }
            board.AddRange(new List<TileDTO>
            {
                new TileDTO
                {
                    Row = 1,
                    Column = TableColumn.A,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.Black,
                        Type = ChessPieceType.Rook,
                        IconUrl = "/Assets/black-rook.svg"
                    }
                },
                new TileDTO
                {
                    Row = 1,
                    Column = TableColumn.B,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.Black,
                        Type = ChessPieceType.Knight,
                        IconUrl = "/Assets/black-knight.svg"
                    }
                },
                new TileDTO
                {
                    Row = 1,
                    Column = TableColumn.C,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.Black,
                        Type = ChessPieceType.Bishop,
                        IconUrl = "/Assets/black-bishop.svg"
                    }
                },
                new TileDTO
                {
                    Row = 1,
                    Column = TableColumn.D,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.Black,
                        Type = ChessPieceType.Queen,
                        IconUrl = "/Assets/black-queen.svg"
                    }
                },
                new TileDTO
                {
                    Row = 1,
                    Column = TableColumn.E,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.Black,
                        Type = ChessPieceType.King,
                        IconUrl = "/Assets/black-king.svg"
                    }
                },
                new TileDTO
                {
                    Row = 1,
                    Column = TableColumn.F,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.Black,
                        Type = ChessPieceType.Bishop,
                        IconUrl = "/Assets/black-bishop.svg"
                    }
                },
                new TileDTO
                {
                    Row = 1,
                    Column = TableColumn.G,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.Black,
                        Type = ChessPieceType.Knight,
                        IconUrl = "/Assets/black-knight.svg"
                    }
                },
                new TileDTO
                {
                    Row = 1,
                    Column = TableColumn.H,
                    ChessPiece = new ChessPieceDTO
                    {
                        Side = Side.Black,
                        Type = ChessPieceType.Rook,
                        IconUrl = "/Assets/black-rook.svg"
                    }
                }
            });

            return board;
        }
    }
}
