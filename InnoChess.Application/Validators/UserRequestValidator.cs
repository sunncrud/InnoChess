using FluentValidation;
using InnoChess.Application.DTO.UserDto;

namespace InnoChess.Application.Validators;

public class UserRequestValidator : AbstractValidator<UserRequest>
{
    public UserRequestValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Email is required");
    }
}