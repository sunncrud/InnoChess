using System.ComponentModel.DataAnnotations;
using FluentValidation;
using InnoChess.Application.DTO.AuthDto;
using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.Services;
using Microsoft.AspNetCore.Mvc;

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
        IValidator<UserRegistrationRequest> userRegistrationRequestValidator,
        CancellationToken cancellationToken)
    {
        var validationResult = await userRegistrationRequestValidator.ValidateAsync(registerUserRequest, cancellationToken);
        if (!validationResult.IsValid)
        {
            var problemDetails = new HttpValidationProblemDetails(validationResult.ToDictionary())
            {
                Status = StatusCodes.Status400BadRequest,
            };
            return Results.Problem(problemDetails);
        }
        
        await userService.Register(registerUserRequest.UserName, registerUserRequest.Email, 
            registerUserRequest.Password, cancellationToken);
        
        return Results.Ok();
    }

    private static async Task<IResult> Login(UserLoginRequest userLoginUserRequest, UserService userService,
        IValidator<UserLoginRequest> userLoginRequestValidator,
        CancellationToken cancellationToken, HttpContext httpContext)
    {
        var validationResult = await userLoginRequestValidator.ValidateAsync(userLoginUserRequest, cancellationToken);
        if (!validationResult.IsValid)
        {
            var problemDetails = new HttpValidationProblemDetails(validationResult.ToDictionary())
            {
                Status = StatusCodes.Status400BadRequest,
            };
            return Results.Problem(problemDetails);
        }
        
        var token = await userService.Login(userLoginUserRequest.Email, userLoginUserRequest.Password, 
            cancellationToken);
        
        httpContext.Response.Cookies.Append("tasty-auth-token", token);
        
        return Results.Ok(token);
    }
    
}