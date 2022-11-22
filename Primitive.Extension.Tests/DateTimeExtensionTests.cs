// Copyright (c) VajraTechMinds.com. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Primitive.Extensions;

namespace Primitive.Extension.Tests;

public class DateTimeExtensionTests
{
    [Theory]
    [InlineData("10/11/2020", "dd/MM/yyyy")]
    [InlineData("10-11-2020", "dd-MM-yyyy")]
    [InlineData("11-10-2020", "MM-dd-yyyy")]
    public void VerifyToDate(string dateString, string format)
    {
        var resultDate = dateString.ToDateTime(format);
        Assert.Equal(new DateTime(2020, 11, 10), resultDate);
    }

    [Fact]
    public void VerifyToEpochDate()
    {
        var expectedDate = new DateTime(2020, 10, 10, 0, 0, 0, DateTimeKind.Utc);
        var epochSeconds = new DateTime(2020, 10, 10).ToEpochTime();
        var actualDate = DateTimeOffset.FromUnixTimeSeconds((long)epochSeconds);
        Assert.Equal(expectedDate, actualDate);
    }

    [Theory]
    [InlineData("10/11/2020", "dd/MM/yyyy", true)]
    [InlineData("10-11-2020", "dd-MM-yyyy", true)]
    [InlineData("10-11-2020", "MM-dd-yyyy", true)]
    [InlineData("13-11-2020", "MM-dd-yyyy", false)]
    [InlineData("13-32-2020", "MM-dd-yyyy", false)]
    public void VerifyIsValidDateTime(string date, string format, bool expectedResult)
    {
        var result = date.IsValid(out _, format);
        Assert.Equal(expectedResult, result);
    }

}