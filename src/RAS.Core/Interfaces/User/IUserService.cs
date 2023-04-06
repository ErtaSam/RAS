using RAS.Core.Aggregates.User.Entities;

namespace RAS.Core.Interfaces.User;

public interface IUserService
{
    Task<UserEntity> GetUser(Guid userId, CancellationToken cancellationToken = default);

    Task<UserEntity> CreateUser(UserEntity request, CancellationToken cancellationToken = default);
}
