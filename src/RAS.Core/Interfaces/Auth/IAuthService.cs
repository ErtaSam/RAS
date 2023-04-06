using RAS.Core.Aggregates.Auth;
using RAS.Core.Aggregates.Auth.Requests;

namespace RAS.Core.Interfaces.Auth;

public interface IAuthService
{
    Task<Authentication> Authenticate(LoginRequest request, CancellationToken cancellationToken = default);
    Task Register(RegisterRequest request, CancellationToken cancellationToken = default);
}
