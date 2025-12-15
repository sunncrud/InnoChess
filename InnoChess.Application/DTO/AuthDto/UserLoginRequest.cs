namespace InnoChess.Application.DTO.UserDto;

public record UserLoginRequest : BaseDto
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
