using Ardalis.Specification;
using RAS.Core.Aggregates.Order.Entities;
using RAS.Core.Aggregates.Menu.Requests;

namespace RAS.Core.Aggregates.Order.Specs;

public class GetUserOrdersSpec : Specification<OrderEntity>
{
    public GetUserOrdersSpec(Guid userId)
    {

        Query.Where(x => x.UserId == userId);        
    }
}
