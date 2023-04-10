using RAS.Core.Aggregates.Order.Entities;

namespace RAS.Core.Interfaces.Order;

public interface IOrderService
{
    Task<OrderEntity> GetOrder(Guid orderId, CancellationToken cancellationToken = default);

    Task<OrderEntity> CreateOrder(OrderEntity request, CancellationToken cancellationToken = default);
}
