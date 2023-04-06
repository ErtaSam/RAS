using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.User.Entities;
using RAS.Core.Exceptions;
using RAS.Core.Interfaces.Menu;
using Utils.Library.Interfaces;

namespace RAS.Core.Services.Menu;

public class MenuService : IMenuService
{

    public MenuService(IRepository<MenuEntity> menuRepo)
    {
        MenuRepo = menuRepo ?? throw new ArgumentNullException(nameof(menuRepo));
    }

    private IRepository<MenuEntity> MenuRepo { get; }

    public async Task<ICollection<MenuEntity>> GetMenu(CancellationToken cancellationToken = default)
    {
        var menu = await MenuRepo.ListAsync(cancellationToken);
        return menu;
    }
}
