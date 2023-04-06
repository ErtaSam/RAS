using Autofac;
using RAS.Core.Interfaces.Auth;
using RAS.Core.Services.Auth;

namespace RAS.Infrastructure.DependencyInjection;

public class AuthDIModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AuthService>()
            .As<IAuthService>()
            .InstancePerLifetimeScope();
    }
}
