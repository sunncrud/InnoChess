using InnoChess.Domain.Models;
using InnoChess.Infrastructure.Configurations;
using InnoNuggetPackage;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure;

public sealed class InnoChessDbContext(DbContextOptions<InnoDbContext> options) : InnoDbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<LocationEntity> Locations { get; set; }
    public DbSet<SessionEntity> Sessions { get; set; }
    public DbSet<UserInSessionEntity> UsersInGames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.ApplyConfiguration(new SessionConfiguration());
        modelBuilder.ApplyConfiguration(new UserInSessionConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
