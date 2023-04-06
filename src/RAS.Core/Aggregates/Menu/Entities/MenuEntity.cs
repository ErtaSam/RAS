using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Library.Interfaces;

namespace RAS.Core.Aggregates.Menu.Entities;
public class MenuEntity : BaseEntity, IAggregateRoot
{
    public string Type { get; set; } = null!;
    public string Name { get; set; } = null!;

    public List<MenuMenuItemEntity> MenuItems { get; set; } = new();
}
