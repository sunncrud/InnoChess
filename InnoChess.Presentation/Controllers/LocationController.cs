using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Presentation.Controllers;

[ApiController]
[Authorize]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[Route("api/[controller]")]
public class LocationController(ILocationService locationService)
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<LocationResponse>>> GetAll([FromQuery] PageParams pageParams, CancellationToken cancellationToken)
    {
        var entities = locationService.GetAllAsync(pageParams, cancellationToken);
        return await entities;
    }

    [HttpGet("{id:guid}")]
    public async Task<LocationResponse?> GetById([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        var entity = await locationService.GetByIdAsync(key, cancellationToken);
        return entity;
    }

    [HttpPut("{id:guid}")]
    public async Task Update([FromBody]LocationRequest request, CancellationToken cancellationToken)
    {
        await locationService.UpdateAsync(request, cancellationToken);
    }
    
    [HttpPost]
    public async Task<Guid> Create([FromBody]LocationRequest request, CancellationToken cancellationToken)
    {
        var entity = await locationService.CreateAsync(request, cancellationToken);
        return entity;
    }

    [HttpDelete("{id:guid}")]
    public async Task<Guid> Delete([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        await locationService.DeleteAsync(key, cancellationToken);
        return key;
    }
    
    
    [HttpGet("{by-name}")]
    public async Task<ActionResult<LocationResponse?>> GetByNameAsync([FromBody]string name, CancellationToken cancellationToken)
    {
        var entity = await locationService.GetLocationByNameAsync(name, cancellationToken);
        return entity;
    }
    
    [HttpGet("{by-description}")]
    public async Task<ActionResult<LocationResponse?>> GetByDescriptionAsync([FromBody]string description, CancellationToken cancellationToken)
    {
        var entity = await locationService.GetLocationByDescriptionAsync(description, cancellationToken);
        return entity;
    }
}
