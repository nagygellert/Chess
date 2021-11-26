using Chess.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.EntityConfigurations
{
    public class LobbyConfigEntityTypeConfiguration : IEntityTypeConfiguration<LobbyConfig>
    {
        public void Configure(EntityTypeBuilder<LobbyConfig> builder)
        {
            builder.HasMany(p => p.Players).WithOne().HasForeignKey(p => p.LobbyConfigId);
        }
    }
}
