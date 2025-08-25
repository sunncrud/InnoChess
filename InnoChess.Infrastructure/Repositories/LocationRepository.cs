using InnoChess.Application.DTO.LocationDto;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure.Repositories;

public class LocationRepository(InnoChessDbContext context) : RepositoryBase<LocationEntity>(context), ILocationRepository
{
    public async Task<LocationEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Locations
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<LocationEntity?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _context.Locations
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == name);
    }
    public async Task<LocationEntity?> GetByDescriptionAsync(string desctiption, CancellationToken cancellationToken)
    {
        return await _context.Locations
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Description == desctiption);
    }

}
