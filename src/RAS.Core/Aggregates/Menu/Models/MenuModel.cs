using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAS.Core.Aggregates.Menu.Entities;

namespace RAS.Core.Aggregates.Menu.Models;
public class MenuModel
{
    public Guid Id { get; set; }
    public string Type { get; set; } = null!;
    public string Name { get; set; } = null!;

    public List<MenuItemModel> MenuItems { get; set; } = new();
}