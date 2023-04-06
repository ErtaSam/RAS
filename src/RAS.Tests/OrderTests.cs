using Moq;
using RAS.Core.Aggregates.Order.Entities;
using RAS.Core.Exceptions;
using RAS.Core.Interfaces.User;
using Utils.Library.Interfaces;

namespace RAS.Tests;
public class OrderTests
{
    [Fact]
    public async Task OrderCancelled()
    {
        var order = new OrderEntity();

        order.Cancelled();
        Assert.True(order.Status == "Cancelled");
    }

    [Fact]
    public async Task OrderPaid()
    {
        var order = new OrderEntity();

        order.Cancelled();
        Assert.True(order.Status == "Paid");
    }

    [Fact]
    public async Task OrderApproved()
    {
        var order = new OrderEntity();

        order.Cancelled();
        Assert.True(order.Status == "Approved");
    }

    [Fact]
    public async Task OrderBeingPrepared()
    {
        var order = new OrderEntity();

        order.Cancelled();
        Assert.True(order.Status == "BeingPrepared");
    }

    [Fact]
    public async Task OrderPrepared()
    {
        var order = new OrderEntity();

        order.Cancelled();
        Assert.True(order.Status == "Prepared");
    }


}
