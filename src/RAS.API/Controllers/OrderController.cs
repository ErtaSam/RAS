using Microsoft.AspNetCore.Mvc;
using RAS.Core.Aggregates.Order.Entities;
using RAS.Core.Aggregates.Order.Models;
using RAS.Core.Interfaces.Order;
using System.Threading.Tasks;

namespace RAS.API.Controllers;

[ApiController]
[Route("api/order")]
public class OrderController : BaseController
{
    public OrderController(IOrderService orderService)
    {
        OrderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    private IOrderService OrderService { get; }

    [HttpGet]
    public async Task<ICollection<OrderModel>> GetOrders(CancellationToken cancellationToken = default)
    {
        var response = await OrderService.GetOrders(Caller.UserId, cancellationToken);
        return Mapper.Map<ICollection<OrderModel>>(response);
    }

    [HttpGet("{orderId:Guid}")]
    public async Task<OrderModel> GetOrder([FromRoute] Guid orderId, CancellationToken cancellationToken = default)
    {
        var response = await OrderService.GetOrder(orderId, cancellationToken);
        return Mapper.Map<OrderModel>(response);
    }

    [HttpPost]
    public async Task<OrderModel> CreateOrder([FromBody] OrderModel request, CancellationToken cancellationToken = default)
    {
        var response = await OrderService.CreateOrder(Caller.UserId, Mapper.Map<OrderEntity>(request), cancellationToken);
        return Mapper.Map<OrderModel>(response);
    }
}
