using RAS.Core.Aggregates.Order.Entities;

namespace RAS.Core.Aggregates.Order.Models;

public class OrderModel
{
    public Guid Id { get; set; }

    public string Status { get; set; } = null!;
    public decimal Sum { get; set; }

    public OrderEntity ToEntity(Guid id) => new()
    {
        Id = id,
        Status = Status,
        Sum = Sum
    };

}
