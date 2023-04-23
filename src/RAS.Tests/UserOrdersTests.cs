using Autofac.Core;
using Moq;
using RAS.Core.Aggregates.Order.Entities;
using RAS.Core.Aggregates.User.Entities;
using RAS.Core.Exceptions;
using RAS.Core.Interfaces.Order;
using Utils.Library.Interfaces;

namespace RAS.Tests;

public class UserOrdersTests
{
    [Fact]
    public async Task LastOrdersFoundFive()
    {
        var orderService = GetOrderService(-11, -6);

        var orders = await orderService.GetLastUserOrders(User.Id);

        Assert.True(orders.Count() == 5);
    }

    [Fact]
    public async Task LastOrdersNotFound()
    {
        var orderService = GetOrderService(-20, -15);

        var orders = await orderService.GetLastUserOrders(User.Id);

        Assert.True(orders.Count() == 0);
    }
    private IOrderService GetOrderService(int startMonth, int endMonth)
    {
        var mockOrderRepo = new Mock<IRepository<OrderEntity>>();

        DateTime[] dates = new DateTime[7];
        var index = 0;
        DateTime today = DateTime.Today;

        for (int i = startMonth; i < endMonth; i++)
        {
            dates[index] = (today.AddMonths(i));
            index++;
        }
              
        mockOrderRepo
              .Setup(repo => repo.ListAsync(CancellationToken.None))
              .ReturnsAsync(Orders(dates));

        return new Core.Services.Order.OrderService(mockOrderRepo.Object);
    }

    #region Data
    private List<OrderEntity> Orders(DateTime[] dates) => new()
{
    new ()
    {
        UserId = new Guid("406AD398-D14C-4C38-81CC-09D835B3EE1F"),
        CreatedAt = new DateTimeOffset(
            DateTime.SpecifyKind(dates[0], DateTimeKind.Utc), TimeSpan.Zero),
        Id = new Guid("706351f1-e5b8-4c2e-b5a0-223c0b579b71"),
    },
    new ()
    {
        UserId = new Guid("406AD398-D14C-4C38-81CC-09D835B3EE1F"),
        CreatedAt = new DateTimeOffset(
            DateTime.SpecifyKind(dates[1], DateTimeKind.Utc), TimeSpan.Zero),
        Id = new Guid("82cbeba2-8113-494d-b7c2-3e6832b20f06"),
    },
    new ()
    {
        UserId = new Guid("406AD398-D14C-4C38-81CC-09D835B3EE1F"),
        CreatedAt = new DateTimeOffset(
            DateTime.SpecifyKind(dates[2], DateTimeKind.Utc), TimeSpan.Zero),
        Id = new Guid("af79038d-fa42-4fab-ac9f-f8b7b9c64a0a"),
    },
    new ()
    {
        UserId = new Guid("406AD398-D14C-4C38-81CC-09D835B3EE1F"),
        CreatedAt = new DateTimeOffset(
            DateTime.SpecifyKind(dates[3], DateTimeKind.Utc), TimeSpan.Zero),
        Id = new Guid("93c735f3-9f64-4144-9892-c04d126c9135"),
    },
    new ()
    {
        UserId = new Guid("406AD398-D14C-4C38-81CC-09D835B3EE1F"),
        CreatedAt = new DateTimeOffset(
            DateTime.SpecifyKind(dates[4], DateTimeKind.Utc), TimeSpan.Zero),
        Id = new Guid("4e2f0230-191b-4474-8db5-07d5c0c70631"),
    },
    new ()
    {
        UserId = new Guid("406AD398-D14C-4C38-81CC-09D835B3EE1F"),
        CreatedAt = new DateTimeOffset(
            DateTime.SpecifyKind(dates[5], DateTimeKind.Utc), TimeSpan.Zero),
        Id = new Guid("da110340-4cc0-4a8e-8317-4c937b731cdd"),
    },
    new ()
    {
        UserId = new Guid("406AD398-D14C-4C38-81CC-09D835B3EE1F"),
        CreatedAt = new DateTimeOffset(2020, 1, 1, 8, 6, 32, 
            new TimeSpan(1, 0, 0)),
        Id = new Guid("615f1d14-aaf0-4b15-9d2a-7e74bde38686"),
    }
};

    private UserEntity User => new()
    {
        Id = new Guid("406AD398-D14C-4C38-81CC-09D835B3EE1F"),
    };
    #endregion
}