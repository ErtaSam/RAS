using AutoMapper;
using RAS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RAS.API.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IMapper Mapper =>
        HttpContext.RequestServices.GetRequiredService<IMapper>();

    protected IConfiguration Configuration =>
        HttpContext.RequestServices.GetRequiredService<IConfiguration>();

    protected ICallerAccessor Caller =>
        HttpContext.RequestServices.GetRequiredService<ICallerAccessor>();
}
