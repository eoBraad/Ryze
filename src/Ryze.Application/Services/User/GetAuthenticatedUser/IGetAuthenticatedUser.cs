namespace Ryze.Application.Services.User.GetAuthenticatedUser;

public interface IGetAuthenticatedUser
{
    Task<Domain.Entities.User?> ExecuteAsync(Guid userId);
}