// Copyright (c) VajraTechMinds.com. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extension.Tests;
using Primitive.Extensions;
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
