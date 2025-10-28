using InnoChess.Application.ServiceContracts;
using Microsoft.AspNetCore.Mvc;


namespace InnoChess.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class CrudController<TRequest, TResponse, TKey>(ICrudService<TRequest, TResponse, TKey> crudService)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<TResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = crudService.GetAllAsync(cancellationToken);
        return await entities;
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<TResponse?> GetById([FromRoute]TKey key, CancellationToken cancellationToken)
    {
        var entity = await crudService.GetByIdAsync(key, cancellationToken);
        return entity;
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task Update([FromBody]TRequest request, CancellationToken cancellationToken)
    {
        await crudService.UpdateAsync(request, cancellationToken);
    }
    
    [HttpPost("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<TKey> Create([FromBody]TRequest request, CancellationToken cancellationToken)
    {
        var entity = await crudService.CreateAsync(request, cancellationToken);
        return entity;
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<TKey> Delete([FromRoute]TKey key, CancellationToken cancellationToken)
    {
        await crudService.DeleteAsync(key, cancellationToken);
        return key;
    }
}