using FluentValidation;
using Ryze.Application.Services.Lead.UserCreateLead.Dto;

namespace Ryze.Application.Services.Lead.UserCreateLead;

public class UserCreateLeadRequestValidator : AbstractValidator<UserCreateLeadRequestDto>
{
    public UserCreateLeadRequestValidator()
    {
        RuleFor(l => l.Description)
            .MinimumLength(5)
            .WithMessage("Description must be at least 5 characters long.");
        RuleFor(l => l.FirstName)
            .MinimumLength(2)
            .WithMessage("First name must be at least 2 characters long.");
        RuleFor(l => l.LastName)
            .MinimumLength(2)
            .WithMessage("Last name must be at least 2 characters long.");
        RuleFor(l => l.Email)
            .EmailAddress()
            .WithMessage("Email must be a valid email address.");
        RuleFor(l => l.Phone)
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .WithMessage("Phone number must be a valid international format.");
        RuleFor(l => l.LeadOrigin)
            .IsInEnum()
            .WithMessage("Lead origin must be a valid enum value.");
    }
}