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
public class UserInSessionController(IUserInSessionService userInSessionService) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<PagedResult<UserInSessionResponse>>> GetAll([FromQuery] PageParams pageParams, CancellationToken cancellationToken)
    {
        var entities = userInSessionService.GetAllAsync(pageParams, cancellationToken);
        return await entities;
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UserInSessionResponse?>> GetById([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        var entity = await userInSessionService.GetByIdAsync(key, cancellationToken);
        return entity;
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Guid>> Delete([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        await userInSessionService.DeleteAsync(key, cancellationToken);
        return key;
    }
}
