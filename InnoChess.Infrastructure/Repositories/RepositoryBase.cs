using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
     where T : class
    {
        protected readonly InnoChessDbContext _context;

        public RepositoryBase(InnoChessDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task CreateAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>()
                .AddAsync(entity, cancellationToken);
            await _context
                .SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
