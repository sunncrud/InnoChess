using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure.Repositories;

public class LocationRepository(InnoChessDbContext context) : RepositoryBase<LocationEntity>(context), ILocationRepository
{
    private readonly InnoChessDbContext _context = context;

    public async Task<LocationEntity?> GetByDescriptionAsync(string desctiption, CancellationToken cancellationToken)
    {
        return await _context.Locations
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Description == desctiption);
    }
}
