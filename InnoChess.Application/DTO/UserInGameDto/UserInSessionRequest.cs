namespace InnoChess.Application.DTO.UserInGameDto;

public record UserInSessionRequest() : BaseDto
{ 
    public Guid UserId { get; set; }
}