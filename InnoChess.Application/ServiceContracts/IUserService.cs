namespace InnoChess.Application.ServiceContracts;

public interface IUserService
{
    public Task Register(string userName, string email, string password, CancellationToken cancellationToken);
    public Task<string> Login(string email, string password, CancellationToken cancellationToken);
}