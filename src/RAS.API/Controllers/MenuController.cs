using System.Threading;
using Microsoft.AspNetCore.Mvc;
using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.Menu.Models;
using RAS.Core.Interfaces.Menu;
using RAS.Core.Services.Menu;

namespace RAS.API.Controllers;

[ApiController]
[Route("api/menu")]
public class MenuController : BaseController
{
    public MenuController(IMenuService menuService)
    {
        MenuService = menuService ?? throw new ArgumentNullException(nameof(menuService));
    }

    private IMenuService MenuService { get; }

    [HttpGet("{menuItemId:Guid}")]
    public async Task<MenuItemModel> GetMenuItem([FromRoute] Guid menuItemId, CancellationToken cancellationToken = default)
    {
        var response = await MenuService.GetMenuItem(menuItemId, cancellationToken);
        return Mapper.Map<MenuItemModel>(response);
    }

    [HttpPost("menuItem")]
    public async Task<MenuItemModel> CreateMenuItem([FromBody] MenuItemModel request, CancellationToken cancellationToken = default)
    {
        var response = await MenuService.CreateMenuItem(Mapper.Map<MenuItemEntity>(request), cancellationToken);
        return Mapper.Map<MenuItemModel>(response);
    }

    [HttpGet]
    public async Task<ICollection<MenuModel>> GetMenu(CancellationToken cancellationToken = default)
    {
        var response = await MenuService.GetMenu(DateTime.Now, cancellationToken);
        return Mapper.Map<ICollection<MenuModel>>(response);
    }

    [HttpPost]
    public async Task<MenuModel> CreateMenu([FromBody] MenuModel request, CancellationToken cancellationToken = default)
    {
        var response = await MenuService.CreateMenu(Mapper.Map<MenuEntity>(request), cancellationToken);
        return Mapper.Map<MenuModel>(response);
    }
}


