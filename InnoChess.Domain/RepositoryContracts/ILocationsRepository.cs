using InnoChess.Domain.Models;

namespace InnoChess.Domain.RepositoryContracts;

public interface ILocationsRepository : IRepositoryBase<LocationEntity>
{
    public Task<List<LocationEntity>> GetAll(CancellationToken cancellationToken);
    public Task<LocationEntity> GetById(CancellationToken cancellationToken);
    public Task<LocationEntity> GetByDescription(CancellationToken cancellationToken);
}
