using Primitive.Extensions;

namespace Primitive.Extension.Tests;

public class NumberExtensionTests
{
    [Fact]
    public void VerifyConvertingEpochToDateTime()
    {
        var date = new DateTime(2000, 10, 10, 10, 10, 10);
        var epochTime = date.ToEpochTime();
        var actualDate = epochTime.ToDateTime();
        Assert.Equal(date, actualDate);

    }
}