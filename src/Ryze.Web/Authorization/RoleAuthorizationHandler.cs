using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Ryze.Web.Authorization;

public class RoleAuthorizationRequirement(params string[] roles) : IAuthorizationRequirement
{
    public string[] Roles { get; } = roles;
}

public class RoleAuthorizationHandler : AuthorizationHandler<RoleAuthorizationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleAuthorizationRequirement requirement)
    {
       var userRoles = context.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
        if (userRoles.Any(role => requirement.Roles.Contains(role)))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}