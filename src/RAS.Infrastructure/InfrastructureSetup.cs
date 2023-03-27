using Microsoft.Extensions.DependencyInjection;
using RAS.Infrastructure.Data;

namespace RAS.Infrastructure;

public static class InfrastructureSetup
{
    public static void AddAppDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(connectionString));
}
