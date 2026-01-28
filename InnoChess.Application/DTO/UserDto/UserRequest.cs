using System.Text.Json.Serialization;

namespace InnoChess.Application.DTO.UserDto;

public record UserRequest : BaseDto
{
    public string UserName { get; init; } = string.Empty;
}
