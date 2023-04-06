using Autofac;
using RAS.Core.Interfaces.User;
using RAS.Core.Services.User;

namespace RAS.Infrastructure.DependencyInjection;

public class UserDIModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserService>()
            .As<IUserService>()
            .InstancePerLifetimeScope();
    }
}
