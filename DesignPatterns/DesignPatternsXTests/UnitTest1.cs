using DesignPatterns;

namespace DesignPatternsXTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

        var result = First.Sum(1, 2);

        Assert.Equal(3, result);
    }
}
