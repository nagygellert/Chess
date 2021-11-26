﻿using Chess.DAL.Contexts;
using Chess.DAL.Repositories.Interfaces;
using Chess.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Services
{
    public class LobbyRepository : ILobbyRepository
    {
        private readonly ChessDbContext _chessDbContext;

        public LobbyRepository(ChessDbContext chessDbContext)
        {
            _chessDbContext = chessDbContext;
        }

        public async Task<IEnumerable<Move>> GetTableState(string lobbyName)
        {
            return (await _chessDbContext.Lobbies.Include(lobby => lobby.Moves).FirstOrDefaultAsync(lobby => lobby.LobbyConfig.Name == lobbyName)).Moves;
        }

        public async Task<Lobby> InsertLobby(Lobby lobby)
        {
            await _chessDbContext.Lobbies.AddAsync(lobby);
            await _chessDbContext.SaveChangesAsync();
            return lobby;
        }

        public async Task<Lobby> InsertMoveReference(Guid lobbyId, Guid moveId)
        {
            //    var lobby = await _lobbyCollection.Find(lobby => lobby.Id == lobbyId).FirstOrDefaultAsync();
            //    //var updatedMoves = lobby.MoveIds.Append(moveId);
            //    var update = Builders<Lobby>.Update.Set(nameof(lobby.MoveIds), updatedMoves);
            //    await _lobbyCollection.UpdateOneAsync(lobby => lobby.Id == lobbyId, update);
            //    return lobby;
            throw new NotImplementedException();
        }

        public Lobby UpdateLobby(Lobby lobby)
        {
            _chessDbContext.Lobbies.Update(lobby);
            return lobby;
        }

        public async Task DeleteLobby(string lobbyName)
        {
            var lobbyToDelete = await _chessDbContext.Lobbies.FirstOrDefaultAsync(lobby => lobby.LobbyConfig.Name == lobbyName);
            _chessDbContext.Lobbies.Remove(lobbyToDelete);
            await _chessDbContext.SaveChangesAsync();
        }

        public async Task<Lobby> GetLobbyByName(string lobbyName)
        {
            return await _chessDbContext.Lobbies.FirstOrDefaultAsync(lobby => lobby.LobbyConfig.Name == lobbyName);
        }
    }
}
