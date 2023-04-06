using RAS.Core.Aggregates.Auth;
using RAS.Core.Interfaces;
using System.Globalization;
using System.Security.Claims;

namespace RAS.Core.Services.Auth;

public static class AuthenticationClaimsFactory
{
    public static ICollection<Claim> FromAuthentication(Authentication authentication)
    {
        var claims = new List<Claim>
        {
            new Claim(nameof(ICallerAccessor.UserId), authentication.User.Id.ToString("D", CultureInfo.InvariantCulture))
        };
        return claims;
    }
}
