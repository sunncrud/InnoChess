namespace InnoChess.Application.DTO.UserInGameDto;

public record UserInSessionRequest()
{ 
    public Guid UserId { get; set; }
}