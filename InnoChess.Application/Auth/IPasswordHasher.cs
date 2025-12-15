namespace InnoChess.Infrastructure;

public interface IPasswordHasher
{
    public string Generate(string password);
    bool Verify(string password, string hashedPassword);
}