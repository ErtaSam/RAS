using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Library.Interfaces;

namespace RAS.Core.Aggregates.Menu.Entities;
public class MenuItemEntity : BaseEntity, IAggregateRoot
{
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public decimal Price { get; set; }
}
