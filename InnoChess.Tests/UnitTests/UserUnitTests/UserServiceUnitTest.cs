using InnoChess.Application.Services;
using InnoChess.Application.Auth;
using InnoChess.Application.Caching;
using InnoChess.Application.MappingContracts;
using InnoChess.Domain.RepositoryContracts;
using InnoChess.Domain.Models;
using Moq;
using Xunit;

namespace InnoChess.Tests.UserUnitTests;

public class UserServiceUnitTest
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IPasswordHasher> _passwordHasherMock;
    private readonly Mock<IJwtProvider> _jwtProviderMock;

    private readonly UserService _userService;

    public UserServiceUnitTest()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        var userMapperMock = new Mock<IUserMapper>();
        _passwordHasherMock = new Mock<IPasswordHasher>();
        _jwtProviderMock = new Mock<IJwtProvider>();
        var cacheServiceMock = new Mock<ICacheService>();
        
        _userService = new UserService(
            _userRepositoryMock.Object,
            userMapperMock.Object,
            _passwordHasherMock.Object,
            _jwtProviderMock.Object,
            cacheServiceMock.Object
        );
    }
    

    [Fact]
    public async Task RegisterUser_ShouldReturnFailure_WhenEmailExists()
    {
        // Arrange
        var email = "existing@test.com";
        var password = "Password123!";
        var username = "TestUser";
        
        _userRepositoryMock
            .Setup(x => x.GetByEmail(email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new UserEntity()); 

        // Act
        Func<Task> act = async () => await _userService.Register(username, email, password, CancellationToken.None);

        // Assert
        await Assert.ThrowsAsync<InvalidOperationException>(act);
    }

    [Fact]
    public async Task Register_ShouldHashPasswordAndCreateUser_WhenValidDataProvided()
    {
        // Arrange
        var userName = "testuser";
        var email = "new@test.com";
        var password = "password123";
        var hashedPassword = "hashed_password123";

        _userRepositoryMock.Setup(x => x.GetByEmail(email, It.IsAny<CancellationToken>()))
            .ReturnsAsync((UserEntity?)null);

        _passwordHasherMock.Setup(x => x.Generate(password))
            .Returns(hashedPassword);

        // Act
        await _userService.Register(userName, email, password, CancellationToken.None);

        // Assert
        _passwordHasherMock.Verify(x => x.Generate(password), Times.Once);
        _userRepositoryMock.Verify(x => x.CreateAsync(
            It.Is<UserEntity>(u => u.Email == email && u.PasswordHash == hashedPassword), 
            It.IsAny<CancellationToken>()), 
            Times.Once);
    }

    [Fact]
    public async Task Login_ShouldReturnToken_WhenUserExistsAndPassIsValid()
    {
        // Arrange
        var email = "test@example.com";
        var password = "password123";
        var hashedPassword = "hashed_pw";
        var expectedToken = "jwt_token";

        var userEntity = UserEntity.CreateUser(Guid.NewGuid(), "user", email, hashedPassword);

        _userRepositoryMock.Setup(x => x.GetByEmail(email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(userEntity);

        _passwordHasherMock.Setup(x => x.Verify(password, hashedPassword))
            .Returns(true);

        _jwtProviderMock.Setup(x => x.GenerateJwtToken(userEntity))
            .Returns(expectedToken);

        // Act
        var result = await _userService.Login(email, password, CancellationToken.None);

        // Assert
        Assert.Equal(expectedToken, result);
    }
    
    [Fact]
    public async Task Login_ShouldThrowException_WhenPasswordIsIncorrect()
    {
        // Arrange
        var email = "user@example.com";
        var wrongPassword = "WrongPassword123!";
        var correctHash = "CorrectHash";
        
        var user = UserEntity.CreateUser(Guid.NewGuid(), "User", email, correctHash);
        
        _userRepositoryMock
            .Setup(x => x.GetByEmail(email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);
        
        _passwordHasherMock
            .Setup(x => x.Verify(wrongPassword, correctHash))
            .Returns(false);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => 
            _userService.Login(email, wrongPassword, CancellationToken.None));
    }
}