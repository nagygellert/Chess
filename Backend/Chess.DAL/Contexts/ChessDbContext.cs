using Chess.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
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

        public DbSet<Vote> Votes { get; set; }

        public DbSet<UserBase> Users { get; set; }

        public DbSet<RegisteredUser> RegisteredUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            Expression<Func<EntityBase, bool>> softDeleteFilter = del => !del.IsDeleted;
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.ClrType.IsAssignableTo(typeof(EntityBase)) && !(entity.ClrType == typeof(RegisteredUser)))
                {
                    var parameter = Expression.Parameter(entity.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(softDeleteFilter.Parameters.First(), parameter, softDeleteFilter.Body);
                    var lambda = Expression.Lambda(body, parameter);

                    entity.SetQueryFilter(lambda);
                }
            }
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added || t.State == EntityState.Deleted))
            {
                EntityBase entity = entry.Entity as EntityBase;
                if (entity != null)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedAt = DateTime.Now;
                            break;

                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entity.IsDeleted = true;
                            break;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
