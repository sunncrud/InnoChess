using InnoChess.Domain.Models;

namespace InnoChess.Domain.RepositoryContracts;

public interface ILocationRepository : IRepositoryBase<LocationEntity, Guid>
{
    public Task<LocationEntity?> GetByNameAsync(string name, CancellationToken cancellationToken);
    public Task<LocationEntity?> GetByDescriptionAsync(string description, CancellationToken cancellationToken);
}
