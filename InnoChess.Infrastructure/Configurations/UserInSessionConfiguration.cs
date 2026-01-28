using InnoChess.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoChess.Infrastructure.Configurations
{
    public class UserInSessionConfiguration : IEntityTypeConfiguration<UserInSessionEntity>
    {
        public void Configure(EntityTypeBuilder<UserInSessionEntity> builder)
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
