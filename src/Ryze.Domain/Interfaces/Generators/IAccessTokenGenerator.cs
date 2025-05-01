using Ryze.Domain.Entities;

namespace Ryze.Domain.Interfaces.Generators;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}