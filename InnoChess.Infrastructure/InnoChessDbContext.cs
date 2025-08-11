using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnoChess.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;


namespace InnoChess.Domain.Models
{
    public class InnoChessDbContext(DbContextOptions<InnoChessDbContext> options) : DbContext(options)
    {
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<SessionEntity> Sessions { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserInGameEntity> UsersInGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserInGameConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
