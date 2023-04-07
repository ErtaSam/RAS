using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.User.Entities;
using RAS.Core.Exceptions;
using RAS.Core.Interfaces.Menu;
using Utils.Library.Interfaces;

namespace RAS.Core.Services.Menu;

public class MenuService : IMenuService
{

    public MenuService(IRepository<MenuEntity> menuRepo, IRepository<MenuItemEntity> menuItemRepo)
    {
        MenuRepo = menuRepo ?? throw new ArgumentNullException(nameof(menuRepo));
        MenuItemRepo = menuItemRepo ?? throw new ArgumentNullException(nameof(menuItemRepo));
    }

    private IRepository<MenuEntity> MenuRepo { get; }
    private IRepository<MenuItemEntity> MenuItemRepo { get; }

    public async Task<ICollection<MenuEntity>> GetMenu(DateTime dateTime, CancellationToken cancellationToken = default)
    {
        var menu = await MenuRepo.ListAsync(cancellationToken);

        if (dateTime.TimeOfDay <= new TimeSpan(11, 0, 0) && dateTime.TimeOfDay >= new TimeSpan(8, 0, 0))
        {
            return menu.Where(x => x.Type == "Pusryčiai" || x.Type == "Pagrindinis").ToList();
        }
        else if (dateTime.TimeOfDay <= new TimeSpan(14, 0, 0) && dateTime.TimeOfDay >= new TimeSpan(11, 0, 0))
        {
            return menu.Where(x => x.Type == "Pietūs" || x.Type == "Pagrindinis").ToList();

        }
        return menu.Where(x => x.Type == "Pagrindinis").ToList();
    }

    public async Task<MenuItemEntity> GetMenuItem(Guid menuItemId, CancellationToken cancellationToken = default)
    {
        var menuItem = await MenuItemRepo.GetByIdAsync(menuItemId, cancellationToken);

        if (menuItem is null)
        {
            throw new MenuItemNotFoundException(menuItemId);
        }

        return menuItem;
    }

    public async Task<MenuItemEntity> CreateMenuItem(MenuItemEntity request, CancellationToken cancellationToken = default)
    {
        return await MenuItemRepo.AddAsync(request, cancellationToken);
    }
}
