using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Library.Interfaces;

namespace RAS.Core.Aggregates.Order.Entities;

public class OrderEntity : BaseEntity, IAggregateRoot
{
    public string Status { get; set; } = null!;
    public decimal Sum { get; set; }

    public void Cancelled()
    {
    }
    public void Paid()
    {
    }
    public void Approved()
    {
    }
    public void BeingPrepared()
    {
    }
    public void Prepared()
    {
    }
}

