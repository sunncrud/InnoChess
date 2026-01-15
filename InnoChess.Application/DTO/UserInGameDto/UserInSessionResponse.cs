namespace InnoChess.Application.DTO.UserInGameDto;

public record UserInSessionResponse()
{
    public Guid SessionId { get; set; }
}