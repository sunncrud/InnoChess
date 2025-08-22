namespace InnoChess.Application.DTO;

public record UserResponse
{
    public Guid Id { get; init; }
    public string UserName { get; init; } = String.Empty;
    public string Email { get; init; } = String.Empty;
}