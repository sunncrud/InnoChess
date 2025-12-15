using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity, TKey>(InnoChessDbContext context) : IRepositoryBase<TEntity, TKey>
        where TEntity : Entity<TKey>
    { 
        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
        {
            return await context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public async Task<TKey> CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await context.Set<TEntity>()
                .AddAsync(entity, cancellationToken);
            await context
                .SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
        public async Task<TKey?> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            context.Set<TEntity>()
                .Update(entity);
            await context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<TKey?> DeleteAsync(TKey id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            if (entity != null) context.Set<TEntity>()
                .Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await context
                .SaveChangesAsync(cancellationToken);
        } 
    }
}
