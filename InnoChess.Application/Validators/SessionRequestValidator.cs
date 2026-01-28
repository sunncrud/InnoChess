using FluentValidation;
using FluentValidation.Validators;
using InnoChess.Application.DTO.SessionDto;

namespace InnoChess.Application.Validators;

public class SessionRequestValidator : AbstractValidator<SessionRequest>
{
    public SessionRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.MaxPlayers)
            .GreaterThan(0).WithMessage("MaxPlayers must be greater than 0")
            .LessThan(10).WithMessage("MaxPlayers must be less than 10");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(50).WithMessage("Description must not exceed 50 characters");
        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required");
    }
}