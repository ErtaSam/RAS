using Ardalis.Specification;
using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.User.Entities;

namespace RAS.Core.Aggregates.Menu.Specs;

public class GetMenuSpec : Specification<MenuEntity>
{
    public GetMenuSpec()
    {
        Query
            .Include(x => x.MenuItems)
                .ThenInclude(x => x.MenuItem);
    }
}
