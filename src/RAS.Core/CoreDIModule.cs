using Autofac;
using Microsoft.AspNetCore.Http;
using RAS.Core.Interfaces;
using RAS.Core.Services;

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
    }
}
