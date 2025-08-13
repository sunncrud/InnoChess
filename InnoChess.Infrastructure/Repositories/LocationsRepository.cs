using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure.Repositories;

public class LocationsRepository(InnoChessDbContext context) : RepositoryBase<LocationEntity>(context), ILocationsRepository
{
    public async Task<List<LocationEntity>> GetAll(CancellationToken cancellationToken)
    {
        return await 
    }

    public Task<LocationEntity> GetByDescription(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<LocationEntity> GetById(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
