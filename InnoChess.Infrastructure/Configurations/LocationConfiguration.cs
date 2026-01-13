using InnoChess.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoChess.Infrastructure.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(EntityTypeBuilder<LocationEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Sessions)
                .WithOne(x => x.Location);
        }
    }
}
