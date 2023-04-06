using Moq;
using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.User.Entities;
using RAS.Core.Exceptions;
using RAS.Core.Interfaces.Menu;
using RAS.Core.Interfaces.User;
using Utils.Library.Interfaces;

namespace RAS.Tests;
public class MenuServiceTests
{
    [Fact]
    public async Task MenuShownBreakfast()
    {
        var service = GetService();

        var menu = await service.GetMenu();
        var result = menu.Where(x => x.Type != "Pusryčiai").Where(x => x.Type != "Pagrindinis");

        Assert.True(result.Count() == 0);
    }

    private List<MenuEntity> Menu => new()
    {
        new MenuEntity
        {
            Id = Guid.NewGuid(),
            Name = "Menu1",
            Type = "Pusryčiai",
        },
        new MenuEntity
        {
            Id = Guid.NewGuid(),
            Name = "Menu2",
            Type = "Pietūs",
        },
        new MenuEntity
        {
            Id = Guid.NewGuid(),
            Name = "Menu3",
            Type = "Pagrindinis",
        }
    };

    private IMenuService GetService()
    {
        var mockMenuRepo = new Mock<IRepository<MenuEntity>>();
        
        mockMenuRepo
              .Setup(repo => repo.ListAsync(CancellationToken.None))
              .ReturnsAsync(Menu);

        return new Core.Services.Menu.MenuService(mockMenuRepo.Object);
    }
}
