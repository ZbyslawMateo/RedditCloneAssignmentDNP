using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace SharedDomain.Auth;

public class AuthorizationPolicies
{
    
    public static void AddPolicies(IServiceCollection services)
    {
        // Yet, I don't need those polices, but I will keep them for possible further expansion.
        
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("MustBeVia", a =>
                a.RequireAuthenticatedUser().RequireClaim("Domain", "via"));
    
            options.AddPolicy("SecurityLevel4", a =>
                a.RequireAuthenticatedUser().RequireClaim("SecurityLevel", "4", "5"));
    
            options.AddPolicy("MustBeTeacher", a =>
                a.RequireAuthenticatedUser().RequireClaim("Role", "Teacher"));
    
            options.AddPolicy("SecurityLevel2OrAbove", a =>
                a.RequireAuthenticatedUser().RequireAssertion(context =>
                {
                    Claim? levelClaim = context.User.FindFirst(claim => claim.Type.Equals("SecurityLevel"));
                    if (levelClaim == null) return false;
                    return int.Parse(levelClaim.Value) >= 2;
                }));
        });
    }
}