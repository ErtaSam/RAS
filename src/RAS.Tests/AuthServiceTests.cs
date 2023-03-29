using Moq;
using RAS.Core.Aggregates.Auth.Requests;
using RAS.Core.Aggregates.User.Entities;
using RAS.Core.Aggregates.Users.Specs;
using RAS.Core.Exceptions;
using RAS.Core.Interfaces.Auth;
using Utils.Library.Interfaces;

namespace RAS.Tests;

public class AuthServiceTests
{
    private readonly string ValidPassword = "SuperDuperUltraSafe";
    private readonly string InvalidPassword = "SuperDuperUltraSafee";

    [Fact]
    public async Task LoginSuccessful()
    {
        var user = AdminUser;
        user.ChangePassword(ValidPassword);

        var service = GetService(user);

        var request = new LoginRequest()
        {
            Email = AdminUser.Email,
            Password = ValidPassword,
        };

        var response = await service.Authenticate(request);

        Assert.True(response.User.Id == AdminUser.Id);
    }

    [Fact]
    public async Task LoginFailed()
    {
        var user = AdminUser;
        user.ChangePassword(ValidPassword);

        var service = GetService(user);

        var request = new LoginRequest()
        {
            Email = AdminUser.Email,
            Password = InvalidPassword,
        };

        await Assert.ThrowsAsync<IncorrectCredentialsException>(async () => await service.Authenticate(request));
    }

    private UserEntity AdminUser => new()
    {
        Id = new Guid("406AD398-D14C-4C38-81CC-09D835B3EE1F"),
        Email = "admin@admin.admin",
        FirstName = "The name of the Admin",
        LastName = "The last name of the Admin",
    };

    private IAuthService GetService(UserEntity user)
    {
        var mockUserRepo = new Mock<IReadRepository<UserEntity>>();

        mockUserRepo
              .Setup(repo => repo.FirstOrDefaultAsync(
                  It.Is<GetUserByEmailSpec>(x => x.Email == user.Email), CancellationToken.None))
              .ReturnsAsync(user);

        return new Core.Services.Auth.AuthService(mockUserRepo.Object);
    }
}
