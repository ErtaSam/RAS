using Ardalis.Specification;
using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.User.Entities;

namespace RAS.Core.Aggregates.Users.Specs;

public class GetMenuByIdSpec : Specification<MenuEntity>, ISingleResultSpecification
{
    public GetMenuByIdSpec(Guid id)
    {
        Query
            .Where(x => x.Id == id)
            .Include(x => x.MenuItems)
                .ThenInclude(x => x.MenuItem);
    }
}