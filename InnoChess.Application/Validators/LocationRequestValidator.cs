using FluentValidation;
using InnoChess.Application.DTO.LocationDto;

namespace InnoChess.Application.Validators;

public class LocationRequestValidator : AbstractValidator<LocationRequest>
{
    public LocationRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(15).WithMessage("Name must not exceed 15 characters");
        RuleFor(x => x.MaxPlayers)
            .NotEmpty().WithMessage("MaxPlayers is required")
            .LessThan(15).WithMessage("MaxPlayers must be greater than 15");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(50).WithMessage("Description must not exceed 50 characters");
    }
}