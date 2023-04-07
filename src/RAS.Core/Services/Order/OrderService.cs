using RAS.Core.Aggregates.Order.Entities;
using RAS.Core.Exceptions;
using RAS.Core.Interfaces.Order;
using Utils.Library.Interfaces;

namespace RAS.Core.Services.Order;

public class OrderService : IOrderService
{
    public OrderService(IRepository<OrderEntity> orderRepo)
    {
        OrderRepo = orderRepo ?? throw new ArgumentNullException(nameof(orderRepo));
    }

    private IRepository<OrderEntity> OrderRepo { get; }

    public async Task<OrderEntity> GetOrder(Guid orderId, CancellationToken cancellationToken = default)
    {
        var order = await OrderRepo.GetByIdAsync(orderId, cancellationToken);

        if (order is null)
        {
            throw new OrderNotFoundException(orderId);
        }

        return order;
    }

    public async Task<OrderEntity> CreateOrder(OrderEntity request, CancellationToken cancellationToken = default)
    {
        return await OrderRepo.AddAsync(request, cancellationToken);
    }
}