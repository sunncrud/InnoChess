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
    public class SessionConfiguration : IEntityTypeConfiguration<SessionEntity>
    {
        public void Configure(EntityTypeBuilder<SessionEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.UsersInGame)
                .WithOne(x => x.Session);

            builder
                .HasOne(x => x.Location)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.LocationId);
        }
    }
}
