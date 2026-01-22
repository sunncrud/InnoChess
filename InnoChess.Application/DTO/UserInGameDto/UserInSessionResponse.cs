namespace InnoChess.Application.DTO.UserInGameDto;

public record UserInSessionResponse() : BaseDto
{
    public Guid SessionId { get; set; }
}