using System.Text.Json.Serialization;

namespace InnoChess.Application.DTO.UserDto;

public record UserRequest
{
    public enum UserRole
    {
        User = 1,
        Administrator = 2
    }

    public string UserName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;

    [JsonPropertyName("password")]
    public string PasswordHash { get; init; } 
    public UserRole Role { get; init; }
}
