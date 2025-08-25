using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.Mappings;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Presetnation.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserResponse>>> GetAllUsers(CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllUsersAsync(cancellationToken);
        return Ok(users);
    }

    [HttpPost]
    public async Task<Guid> RegisterUser([FromBody] UserRequest user, CancellationToken cancellationToken)
    {
        var entity = UserMapper.ToEntity(user);
        await _userService.CreateUserAsync(entity, cancellationToken);
        return entity.Id;
    }

    [HttpDelete]
    public async Task DeleteUser(Guid id, CancellationToken cancellationToken)
    {
        await _userService.DeleteUserAsync(id, cancellationToken);
    }
}

