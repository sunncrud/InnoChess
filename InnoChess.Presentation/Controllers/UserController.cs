using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.Mappings;
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
[Route("users")]
public class UserController(ICrudService<UserRequest, UserResponse> crudService, IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<UserResponse>>> GetAll([FromQuery] PageParams pageParams, CancellationToken cancellationToken)
    {
        var entities = crudService.GetAllAsync(pageParams, cancellationToken);
        return await entities;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserResponse?>> GetById([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        var entity = await crudService.GetByIdAsync(key, cancellationToken);
        return entity;
    }
    

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Guid>> Delete([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        await crudService.DeleteAsync(key, cancellationToken);
        return key;
    }
}

