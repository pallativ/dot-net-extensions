// Copyright (c) . All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extension.Tests;
using System.Data;
using Primitive.Extensions;

public class DataColumnCollectionExtensionTests
{
    [Fact]
    public void Verify_Adding_Multiple_Columns()
    {
        var table = new DataTable("Sample");
        var columns = new Dictionary<string, Type>
        {
            { "Name", string.Empty.GetType() },
            { "Age", 1.GetType() },
        };
        table.Columns.Add(columns);
        Assert.Equal(2, table.Columns.Count);
        Assert.Equal("Name", table.Columns[0].ColumnName);
        Assert.Equal("Age", table.Columns[1].ColumnName);
        Assert.Equal(new List<string> { "Name", "Age" }, table.GetColumnNames());
    }
}
