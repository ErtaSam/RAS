using RAS.Core.Aggregates.Order.Entities;

namespace RAS.Core.Interfaces.Order;

public interface IOrderService
{
    Task<ICollection<OrderEntity>> GetOrders(Guid userId, CancellationToken cancellationToken = default);

    Task<OrderEntity> GetOrder(Guid orderId, CancellationToken cancellationToken = default);

    Task<OrderEntity> CreateOrder(Guid userId, OrderEntity request, CancellationToken cancellationToken = default);
}
