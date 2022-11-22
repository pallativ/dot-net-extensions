// Copyright (c) VajraTechMinds.com. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extension.Tests;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using Primitive.Extensions;

public class StringExtensionTests
{
    internal enum Name
    {
        FirstName,
        LastName,
    }

    [Fact]
    public void VerifyStringConversionToEnum()
    {
        var actualResult = "FirstName".ToEnum<Name>();
        Assert.Equal(Name.FirstName, actualResult);
        actualResult = "LastName".ToEnum<Name>();
        Assert.Equal(Name.LastName, actualResult);
    }

    [Fact]
    public void VerifyExceptionWhenInvalidValueIsUsed()
    {
        Assert.Throws<ArgumentException>(() => "FirstName1".ToEnum<Name>());
    }
}

public class EnumExtensionTests
{
    internal enum Name
    {
        [Description("First Name")]
        FirstName,
        [Description("Last Name")]
        LastName,
        FullName,
    }

    [Fact]
    public void VerifyGetAttribute()
    {
        var description = Name.FirstName.GetDescription();
        Assert.NotNull(description);
        Assert.Equal("First Name", description);
        var attribute = Name.FirstName.GetAttribute<DescriptionAttribute>();
        Assert.NotNull(attribute);
    }
}
