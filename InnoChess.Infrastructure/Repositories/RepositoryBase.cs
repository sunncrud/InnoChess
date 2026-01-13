using InnoChess.Domain.Models;
using InnoChess.Domain.Primitives;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity>(InnoChessDbContext context) : IRepositoryBase<TEntity>
        where TEntity : class, IEntity<Guid>
    { 
        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return context.Set<TEntity>().AsNoTracking();
        }
        
        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public async Task<Guid> CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await context.Set<TEntity>()
                .AddAsync(entity, cancellationToken);
            await context
                .SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
        public async Task<Guid?> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            context.Set<TEntity>()
                .Update(entity);
            await context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<Guid?> DeleteAsync(Guid id, CancellationToken cancellationToken)
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
