namespace InnoChess.Application.DTO.UserDto;

public record UserResponse 
{
    public Guid Id { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}