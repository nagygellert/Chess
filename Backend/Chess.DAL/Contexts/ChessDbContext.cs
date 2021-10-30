using Chess.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Contexts
{
    public class ChessDbContext : DbContext
    {
        public ChessDbContext(DbContextOptions<ChessDbContext> options) : base(options) { }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<Lobby> Lobbies { get; set; }

        public DbSet<LobbyConfig> LobbyConfigs { get; set; }

        public DbSet<Move> Moves { get; set; }

        public DbSet<PieceLocation> PieceLocations { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<UserBase> TemporaryUsers { get; set; }

        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
    }
}
