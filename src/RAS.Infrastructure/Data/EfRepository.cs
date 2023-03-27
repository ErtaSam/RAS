using Ardalis.Specification.EntityFrameworkCore;
using RAS.Infrastructure.Data;
using Utils.Library.Interfaces;

namespace RAS.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
}
