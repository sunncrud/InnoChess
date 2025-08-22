using InnoChess.Domain.Models;

namespace InnoChess.Domain.RepositoryContracts;

public interface ILocationRepository : IRepositoryBase<LocationEntity>
{
    public Task<LocationEntity?> GetByDescriptionAsync(string desctiption, CancellationToken cancellationToken);
}
