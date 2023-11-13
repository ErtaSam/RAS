using RAS.Core.Aggregates.User.Entities;

namespace RAS.Core.Aggregates.User.Models;

public class UserModel
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Role { get; set; } = null!;

    public UserEntity ToEntity(Guid id) => new()
    {
        Id = id,
        FirstName = FirstName,
        LastName = LastName,
        Phone = Phone,
        Email = Email,
        BirthDate = BirthDate,
        Role = Role
    };

}
