using RAS.Core.Aggregates.User.Entities;
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
    public Guid UserId { get; set; }

    public UserEntity User { get; set; }

    public void Cancelled()
    {
        Status = "Cancelled";
    }
    public void Paid()
    {
        Status = "Paid";
    }
    public void Approved()
    {
        Status = "Approved";
    }
    public void BeingPrepared()
    {
        Status = "Being Prepared";
    }
    public void Prepared()
    {
        Status = "Prepared";
    }
}