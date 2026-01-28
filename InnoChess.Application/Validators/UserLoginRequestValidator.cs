using FluentValidation;
using InnoChess.Application.DTO.AuthDto;

namespace InnoChess.Application.Validators;

public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
{
    public UserLoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is invalid");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}