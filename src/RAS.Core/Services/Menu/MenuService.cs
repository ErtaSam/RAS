using Microsoft.AspNetCore.Mvc;
using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.Menu.Requests;
using RAS.Core.Aggregates.Menu.Specs;
using RAS.Core.Aggregates.Users.Specs;
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

    public async Task<ICollection<MenuEntity>> GetMenu(GetMenuRequest request, DateTime dateTime, CancellationToken cancellationToken = default)
    {
        var spec = new GetMenuSpec(request, dateTime);
        return  await MenuRepo.ListAsync(spec, cancellationToken);
    }
    
    public async Task<MenuEntity> CreateMenu(MenuEntity request, CancellationToken cancellationToken = default)
    {
        await MenuRepo.AddAsync(request, cancellationToken);
        return await MenuRepo.FirstOrDefaultAsync(new GetMenuByIdSpec(request.Id), cancellationToken) ?? throw new MenuItemNotFoundException(); ;
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
