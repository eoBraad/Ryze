﻿using FluentValidation;
using Ryze.Application.Services.Login.LoginUser.Dto;

namespace Ryze.Application.Services.Login.LoginUser;

public class LoginUserValidations : AbstractValidator<LoginUserRequestDto>
{
    public LoginUserValidations()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(u => u.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(5)
            .WithMessage("Password must be at least 6 characters long.");
    }
}