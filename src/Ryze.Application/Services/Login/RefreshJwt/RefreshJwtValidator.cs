using FluentValidation;
using Ryze.Application.Services.Login.RefreshJwt.Dtos;

namespace Ryze.Application.Services.Login.RefreshJwt;

public class RefreshJwtValidator : AbstractValidator<RefreshTokenRequestDto>
{
    public RefreshJwtValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("Refresh token is required");
    }
}