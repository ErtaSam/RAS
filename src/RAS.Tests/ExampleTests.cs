namespace RAS.Tests;

public class ExampleTests
{
    [Fact]
    public async Task ExampleTrue()
    {
        Assert.True(true);
        Assert.True(1 < 2);
    }

    [Fact]
    public async Task ExampleFalse()
    {
        Assert.False(false);
        Assert.False(1 == 2);
    }
}
