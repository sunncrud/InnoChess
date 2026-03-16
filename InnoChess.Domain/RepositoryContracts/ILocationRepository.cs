using InnoChess.Domain.Models;
using InnoNuggetPackage.RepositoryContracts;

namespace InnoChess.Domain.RepositoryContracts;

public interface ILocationRepository : IBaseRepository<LocationEntity>
{
    public Task<LocationEntity?> GetByNameAsync(string name, CancellationToken cancellationToken);
    public Task<LocationEntity?> GetByDescriptionAsync(string description, CancellationToken cancellationToken);
}
