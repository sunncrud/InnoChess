using InnoChess.Domain.Models;

namespace InnoChess.Domain.RepositoryContracts;

public interface ILocationRepository : IRepositoryBase<LocationEntity>
{
    public Task<LocationEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<LocationEntity?> GetByNameAsync(string name, CancellationToken cancellationToken);
    public Task<LocationEntity?> GetByDescriptionAsync(string desctiption, CancellationToken cancellationToken);
}
