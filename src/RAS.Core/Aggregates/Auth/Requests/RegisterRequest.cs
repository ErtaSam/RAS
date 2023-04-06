using RAS.Core.Aggregates.User.Entities;

namespace RAS.Core.Aggregates.Auth.Requests;

public class RegisterRequest
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public UserEntity ToEntity() => new()
    {
        Id = Guid.NewGuid(),
        FirstName = FirstName,
        LastName = LastName,
        Phone = Phone,
        Email = Email,
    };
}
