using FluentValidation;
using Ryze.Application.Services.Login.RefreshJwt.Dto;

namespace Ryze.Application.Services.Login.RefreshJwt;

public class RefreshJwtValidator : AbstractValidator<RefreshTokenRequestDto>
{
    public RefreshJwtValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("Refresh token is required");
    }
}