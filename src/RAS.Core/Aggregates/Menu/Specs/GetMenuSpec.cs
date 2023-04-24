using Ardalis.Specification;
using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.Menu.Requests;

namespace RAS.Core.Aggregates.Menu.Specs;

public class GetMenuSpec : Specification<MenuEntity>
{
    public GetMenuSpec(GetMenuRequest request, DateTime dateTime)
    {
        if (!string.IsNullOrEmpty(request.Name))
        {
            Query
                .Where(x => x.Name.Contains(request.Name));
        }
        if (dateTime.TimeOfDay <= new TimeSpan(11, 0, 0) && dateTime.TimeOfDay >= new TimeSpan(8, 0, 0))
        {
            Query
               .Include(x => x.MenuItems.Where(x => x.MenuItem.Category != "Pietūs"))
                   .ThenInclude(x => x.MenuItem);
        }
        else if (dateTime.TimeOfDay <= new TimeSpan(14, 0, 0) && dateTime.TimeOfDay >= new TimeSpan(11, 0, 0))
        {
            Query
                .Include(x => x.MenuItems.Where(x => x.MenuItem.Category != "Pusryčiai"))
                    .ThenInclude(x => x.MenuItem);
        }
        else
        {
            Query
                .Include(x => x.MenuItems.Where(x => x.MenuItem.Category == "Pagrindinis"))
                    .ThenInclude(x => x.MenuItem);
        }

    }

}