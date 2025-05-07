namespace Ryze.Application.Services.Login.RefreshJwt.Dtos;

public class RefreshTokenResponseDto
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}