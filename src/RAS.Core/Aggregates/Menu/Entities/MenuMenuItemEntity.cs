using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAS.Core.Aggregates.Menu.Entities;
public class MenuMenuItemEntity
{
    public Guid MenuId { get; set; }
    public MenuEntity Menu { get; set; }

    public Guid MenuItemId { get; set; }
    public MenuItemEntity MenuItem { get; set; }
}
