using FluentValidation;
using InnoChess.Application.DTO.UserDto;

namespace InnoChess.Application.Validators;

public class UserRegistrationDtoValidator : AbstractValidator<UserRegistrationDto>
{
    public UserRegistrationDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long");
        
        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm your password")
            .Equal(x => x.Password).WithMessage("Passwords do not match");
    }
}