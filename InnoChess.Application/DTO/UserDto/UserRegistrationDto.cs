namespace InnoChess.Application.DTO.UserDto;

public record UserRegistrationDto : BaseDto
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string ConfirmPassword { get; init; } = string.Empty;
}
