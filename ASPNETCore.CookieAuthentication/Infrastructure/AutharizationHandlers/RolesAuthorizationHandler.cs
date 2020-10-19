using ASPNETCore.CookieAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.CookieAuthentication.Infrastructure.AutharizationHandlers
{
    public class RolesAuthorizationHandler: AuthorizationHandler<RolesAuthorizationRequirement>,IAuthorizationHandler
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            RolesAuthorizationRequirement requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var validRole = false;
            if (requirement.AllowedRoles == null
                || requirement.AllowedRoles.Any() == false)
            {
                validRole = false;
            }
            else
            {
                var claims = context.User.Claims;
                var email = claims.FirstOrDefault(c => c.Type == "UserEmail").Value;
                var roles = requirement.AllowedRoles;

                validRole = new Users().UserList().Any(f => roles.Contains(f.Role) && f.Email == email);
            }

            if (!validRole)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
