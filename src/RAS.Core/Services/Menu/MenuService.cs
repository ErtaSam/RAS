﻿using RAS.Core.Aggregates.Menu.Entities;
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

}
