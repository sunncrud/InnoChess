using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.Services;

namespace InnoChess.Presentation.Endpoints;

public static class UserEndpoint
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);
        app.MapPost("login", Login);
        return app;
    }
    private static async Task<IResult> Register(UserRegistrationRequest registerUserRequest,UserService userService, 
        CancellationToken cancellationToken)
    {
        await userService.Register(registerUserRequest.UserName, registerUserRequest.Email, 
            registerUserRequest.Password, cancellationToken);
        return Results.Ok();
    }

    private static async Task<IResult> Login(UserLoginRequest userLoginUserRequest, UserService userService,
        CancellationToken cancellationToken, HttpContext httpContext)
    {
        var token = await userService.Login(userLoginUserRequest.Email, userLoginUserRequest.Password, 
            cancellationToken);
        
        httpContext.Response.Cookies.Append("tasty-auth-token", token);
        
        return Results.Ok(token);
    }
    
}