using InnoChess.Application.DTO.UserInGameDto;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Presentation.Controllers;
[ApiController]
[Authorize]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[Route("[controller]")]
public class UserInSessionController(IUserInSessionService userInSessionService) 
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<UserInSessionResponse>>> GetAll([FromQuery] PageParams pageParams, CancellationToken cancellationToken)
    {
        var entities = userInSessionService.GetAllAsync(pageParams, cancellationToken);
        return await entities;
    }

    [HttpGet("{id:guid}")]
    public async Task<UserInSessionResponse?> GetById([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        var entity = await userInSessionService.GetByIdAsync(key, cancellationToken);
        return entity;
    }

    [HttpPut("{id:guid}")]
    public async Task Update([FromBody]UserInSessionRequest request, CancellationToken cancellationToken)
    {
        await userInSessionService.UpdateAsync(request, cancellationToken);
    }
    
    [HttpPost]
    public async Task<Guid> Create([FromBody]UserInSessionRequest request, CancellationToken cancellationToken)
    {
        var entity = await userInSessionService.CreateAsync(request, cancellationToken);
        return entity;
    }

    [HttpDelete("{id:guid}")]
    public async Task<Guid> Delete([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        await userInSessionService.DeleteAsync(key, cancellationToken);
        return key;
    }
}
