using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure.Repositories;

public class LocationRepository(InnoChessDbContext context) : RepositoryBase<LocationEntity, Guid>(context), ILocationRepository
{ 
    public async Task<LocationEntity?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;

        var likePattern = $"%{name}%";
        return await _context.Locations
            .AsNoTracking()
            .FirstOrDefaultAsync(x => EF.Functions.Like(x.Name, likePattern), cancellationToken);
    }
    public async Task<LocationEntity?> GetByDescriptionAsync(string desctiption, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(desctiption)) return null;

        var likePattern = $"%{desctiption}%";
        return await _context.Locations
            .AsNoTracking()
            .FirstOrDefaultAsync(x => EF.Functions.Like(x.Description, likePattern), cancellationToken);
    }

}
