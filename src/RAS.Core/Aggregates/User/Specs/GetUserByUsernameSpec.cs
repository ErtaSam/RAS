using Ardalis.Specification;
using RAS.Core.Aggregates.User.Entities;

namespace RAS.Core.Aggregates.Users.Specs;

public class GetUserByEmailSpec : Specification<UserEntity>, ISingleResultSpecification
{
    public GetUserByEmailSpec(string email)
    {
        // Only used for Tests
        Email = email;
        
        Query
            .Where(x => x.Email == email);
    }

    // Only used for Tests
    public string Email { get; set; }
}
