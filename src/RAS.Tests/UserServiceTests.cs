using Moq;
using RAS.Core.Aggregates.User.Entities;
using RAS.Core.Exceptions;
using RAS.Core.Interfaces.User;
using Utils.Library.Interfaces;

namespace RAS.Tests;
public class UserServiceTests
{
    [Fact]
    public async Task UserFound()
    {
        var service = GetService(AdminUser);

        var user = await service.GetUser(AdminUser.Id);

        Assert.True(AdminUser.Id == user.Id);
    }

    [Fact]
    public async Task UserNotFound()
    {
        var id = new Guid("506AD398-D14C-4C38-81CC-09D835B3EE1F");

        var service = GetService(AdminUser);
        await Assert.ThrowsAsync<UserNotFoundException>(async () => await service.GetUser(id));
    }

    private UserEntity AdminUser => new()
    {
        Id = new Guid("406AD398-D14C-4C38-81CC-09D835B3EE1F"),
        Email = "admin@admin.admin",
        FirstName = "The name of the Admin",
        LastName = "The last name of the Admin",
    };

    private IUserService GetService(UserEntity user)
    {
        var mockUserRepo = new Mock<IRepository<UserEntity>>();
        
        mockUserRepo
              .Setup(repo => repo.GetByIdAsync(user.Id, CancellationToken.None))
              .ReturnsAsync(user);

        return new Core.Services.User.OrderService(mockUserRepo.Object);
    }
}
