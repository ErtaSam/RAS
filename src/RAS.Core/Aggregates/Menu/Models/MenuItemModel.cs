using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAS.Core.Aggregates.User.Entities;

namespace RAS.Core.Aggregates.Menu.Models;
public class MenuItemModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public decimal Price { get; set; }
}