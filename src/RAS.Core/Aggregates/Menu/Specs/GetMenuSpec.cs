using Ardalis.Specification;
using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.Menu.Requests;
using RAS.Core.Aggregates.User.Entities;

namespace RAS.Core.Aggregates.Menu.Specs;

public class GetMenuSpec : Specification<MenuEntity>
{
    public GetMenuSpec(GetMenuRequest request)
    {
        if (!string.IsNullOrEmpty(request.Name))
        {
            Query
                .Where(x => x.Name.Contains(request.Name));
        }
        Query
            .Include(x => x.MenuItems)
                .ThenInclude(x => x.MenuItem);
        
    }
}
