using System.Text.Json.Serialization;

namespace InnoChess.Application.DTO;

public record UserRequest
{
    public enum UserRole
    {
        User = 1,
        Administrator = 2
    }

    public string UserName { get; init; } = String.Empty;
    public string Email { get; init; } = String.Empty;

    [JsonPropertyName("password")]
    public string PasswordHash { get; init; } 
    public UserRole Role { get; init; }
}
