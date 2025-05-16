using FluentValidation;
using Ryze.Application.Services.User.CreateUser.Dto;

namespace Ryze.Application.Services.User.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserRequestDto>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MinimumLength(3)
            .WithMessage("Name must be at least 3 characters long.");
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long.");
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .WithMessage("Invalid phone number format.");

        RuleFor(x => x.Gender)
            .NotEmpty()
            .WithMessage("Gender is required.");

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .WithMessage("Birth date is required.");

        RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("Role is required.")
            .IsInEnum()
            .WithMessage("Invalid role.");
    }
}