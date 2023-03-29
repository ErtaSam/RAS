using RAS.Core.Exceptions;
using Utils.Library.Interfaces;
using Utils.Library.Security;

namespace RAS.Core.Aggregates.User.Entities;

public class UserEntity : BaseEntity, IAggregateRoot
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public DateTimeOffset PasswordChangedAt { get; set; }
    
    public byte[] PasswordSalt { get; private set; } = Array.Empty<byte>();
    
    public byte[] PasswordHash { get; private set; } = Array.Empty<byte>();

    #region Password

    public void CheckPassword(string password)
    {
        var passwordHash = PBKDF2Password.Default.ComputeHash(password, PasswordSalt);

        if (!passwordHash.SequenceEqual(PasswordHash))
        {
            throw new IncorrectCredentialsException($"Incorrect credentials.");
        }
    }

    public void ChangePassword(string currentPassword, string newPassword)
    {
        CheckPassword(currentPassword);

        ChangePassword(newPassword);
    }

    public void ChangePassword(string password)
    {
        var hashedPassword = PBKDF2Password.Default.CreateNewPassword(password);
        PasswordHash = hashedPassword.PasswordHash;
        PasswordSalt = hashedPassword.PasswordSalt;

        PasswordChangedAt = DateTime.Now;
    }

    #endregion
}
