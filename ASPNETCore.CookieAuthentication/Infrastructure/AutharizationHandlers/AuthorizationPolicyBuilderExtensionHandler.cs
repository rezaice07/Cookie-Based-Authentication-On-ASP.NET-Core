using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ASPNETCore.CookieAuthentication.Infrastructure.AutharizationHandlers
{
    public static class AuthorizationPolicyBuilderExtensionHandler
    {
        public static AuthorizationPolicyBuilder UserRequireCustomClaim(this AuthorizationPolicyBuilder builder, string claimType)
        {
            builder.AddRequirements(new CustomUserRequireClaim(claimType));

            return builder;
        }

    }
}
