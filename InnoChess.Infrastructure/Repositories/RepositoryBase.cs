using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Infrastructure.Repositories
{
    public class RepositoryBase<T>(InnoChessDbContext context) : IRepositoryBase<T> where T : class
    {
        private readonly InnoChessDbContext _context = context;

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        }
        public async Task CreateAsync(T entity, CancellationToken cancellationToken)
        {
            await context.Set<T>().AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
