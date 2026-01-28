namespace InnoChess.Application.DTO.AuthDto;

public record UserRegistrationRequest : BaseDto
{
    public string UserName { get; init; } = string.Empty;
    public string Email { get; init; } =  string.Empty;
    public string Password { get; init; } =  string.Empty;
    public string ConfirmPassword { get; init; } =  string.Empty;
}