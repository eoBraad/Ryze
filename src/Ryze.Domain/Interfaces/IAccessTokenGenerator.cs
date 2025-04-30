using Ryze.Domain.Entities;

namespace Ryze.Domain.Interfaces;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}