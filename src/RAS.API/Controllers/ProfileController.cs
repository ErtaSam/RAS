using Microsoft.AspNetCore.Mvc;
using RAS.Core.Aggregates.User.Models;
using RAS.Core.Interfaces.User;

namespace RAS.API.Controllers;

[ApiController]
[Route("api/profile")]
public class ProfileController : BaseController
{
    public ProfileController(IUserService userService)
    {
        UserService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    private IUserService UserService { get; }

    [HttpGet]
    public async Task<UserModel> GetCurrentUser(CancellationToken cancellationToken = default)
    {
        var response = await UserService.GetUser(Caller.UserId, cancellationToken);
        return Mapper.Map<UserModel>(response);
    }
}
