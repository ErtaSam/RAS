using RAS.Core.Aggregates.User.Entities;
using RAS.Core.Exceptions;
using RAS.Core.Interfaces.User;
using Utils.Library.Interfaces;

namespace RAS.Core.Services.User;

public class UserService : IUserService
{
    public UserService(IRepository<UserEntity> userRepo)
    {
        UserRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
    }

    private IRepository<UserEntity> UserRepo { get; }

    public async Task<UserEntity> GetUser(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await UserRepo.GetByIdAsync(userId, cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        return user;
    }

    public async Task<UserEntity> CreateUser(UserEntity request, CancellationToken cancellationToken = default)
    {
        return await UserRepo.AddAsync(request, cancellationToken);
    }
}
