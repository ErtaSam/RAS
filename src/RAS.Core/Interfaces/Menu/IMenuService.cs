using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.User.Entities;

namespace RAS.Core.Interfaces.Menu;

public interface IMenuService
{
    Task<ICollection<MenuEntity>> GetMenu(CancellationToken cancellationToken = default);
}
