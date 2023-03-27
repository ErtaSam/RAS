using Autofac;
using RAS.Infrastructure.Data;
using Utils.Library.Interfaces;
using Module = Autofac.Module;

namespace RAS.Infrastructure;

public class InfrastructureDIModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfRepository<>))
           .As(typeof(IRepository<>))
           .As(typeof(IReadRepository<>))
           .InstancePerLifetimeScope();
    }
}
