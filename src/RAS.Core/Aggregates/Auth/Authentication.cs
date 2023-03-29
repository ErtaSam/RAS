using RAS.Core.Aggregates.User.Entities;

namespace RAS.Core.Aggregates.Auth;

public class Authentication
{
    public Authentication(UserEntity user)
    {
        User = user;
    }

    public UserEntity User { get; }
}
