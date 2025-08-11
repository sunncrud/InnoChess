using InnoChess.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Infrastructure.Configurations
{
    public class UserInGameConfiguration : IEntityTypeConfiguration<UserInGameEntity>
    {
        public void Configure(EntityTypeBuilder<UserInGameEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Session)
                .WithMany(x => x.UsersInGame)
                .HasForeignKey(x => x.SessionId);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.UsersInGame)
                .HasForeignKey(x => x.UserId);
        }
    }
}
