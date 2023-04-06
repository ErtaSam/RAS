using Moq;
using RAS.Core.Aggregates.User.Entities;
using RAS.Core.Interfaces;

namespace RAS.Tests;
public static class TestsHelpers
{
    public static Mock<ICallerAccessor> SetupCallerMock(UserEntity user)
    {
        var callerMock = new Mock<ICallerAccessor>();
        callerMock.Setup(x => x.UserId).Returns(user.Id);

        return callerMock;
    }
}
