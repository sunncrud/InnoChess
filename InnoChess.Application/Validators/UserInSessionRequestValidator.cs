using FluentValidation;
using InnoChess.Application.DTO.UserInGameDto;

namespace InnoChess.Application.Validators;

public class UserInSessionRequestValidator : AbstractValidator<UserInSessionRequest>
{
    public UserInSessionRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required");
    }
}