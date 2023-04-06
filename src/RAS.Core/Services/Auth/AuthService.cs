using RAS.Core.Aggregates.Auth;
using RAS.Core.Aggregates.Auth.Requests;
using RAS.Core.Aggregates.User.Entities;
using RAS.Core.Aggregates.Users.Specs;
using RAS.Core.Exceptions;
using RAS.Core.Interfaces.Auth;
using Utils.Library.Interfaces;

namespace RAS.Core.Services.Auth;

public class AuthService : IAuthService
{
    public AuthService(IReadRepository<UserEntity> userRepo)
    {
        UserRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
    }

    private IReadRepository<UserEntity> UserRepo { get; }

    public async Task<Authentication> Authenticate(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var user = await GetUser(request.Email, cancellationToken).ConfigureAwait(false);

        user.CheckPassword(request.Password);

        return new(user);
    }

    public async Task Register(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var user = request.ToEntity();

        user.ChangePassword(request.Password);

        await UserRepo.AddAsync(user, cancellationToken);
    }

    private async Task<UserEntity> GetUser(string email, CancellationToken cancellationToken = default)
    {
        var spec = new GetUserByEmailSpec(email);
        var user = await UserRepo.FirstOrDefaultAsync(spec, cancellationToken) ?? throw new IncorrectCredentialsException("Email or password is incorrect.");

        return user;
    }
}
