using InnoChess.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.RepositoryContracts;

public interface IRepositoryBase<T> where T : class
{
    public Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    public Task CreateAsync(T entity, CancellationToken cancellationToken);
    public Task UpdateAsync(T entity, CancellationToken cancellationToken);
    public Task DeleteAsync(T entity, CancellationToken cancellationToken);
}
