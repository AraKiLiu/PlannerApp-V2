using FluentValidation;
using PlannerApp.Shared.Models;

namespace PlannerApp.Shared.Vailidators;

public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not a valid email address");
        
        
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required")
            .MinimumLength(25).WithMessage("First name is must be less than 25 characters");
        
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
            .MinimumLength(25).WithMessage("Last name is must be less than 25 characters");
        
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password is must be at least 6 characters");

        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword is required")
            .Equal(x => x.Password).WithMessage("ConfirmPassword is not equal to Password");
    }
}