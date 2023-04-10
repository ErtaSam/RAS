using Autofac;
using Microsoft.AspNetCore.Http;
using RAS.Core.Interfaces;
using RAS.Core.Interfaces.Menu;
using RAS.Core.Interfaces.User;
using RAS.Core.Interfaces.Order;
using RAS.Core.Services;
using RAS.Core.Services.Menu;
using RAS.Core.Services.User;
using RAS.Core.Services.Order;
using RAS.Core.Services.User;

namespace RAS.Core;

public class CoreDIModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {

        builder.Register<ICallerAccessor>(builder =>
        {
            var httpContext = builder.Resolve<IHttpContextAccessor>();
            var principal = httpContext.HttpContext?.User;
            if (principal?.Identity is null || !principal.Identity.IsAuthenticated)
            {
                return new CallerAccessor();
            }
            return new CallerAccessor(principal.Claims.ToList());
        }).InstancePerLifetimeScope();

        builder.RegisterType<OrderService>()
            .As<IOrderService>()
            .InstancePerLifetimeScope();

        builder.RegisterType<MenuService>()
            .As<IMenuService>()
            .InstancePerLifetimeScope();
    }
}
