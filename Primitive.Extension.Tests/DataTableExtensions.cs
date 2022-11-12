using System.Data;
using Primitive.Extensions;

namespace Primitive.Extension.Tests;

public class DataTableExtensions
{
    [Fact]
    public void Verify_DataTable_DataTypes()
    {
        var table = new DataTable("Sample");
        var columns = new Dictionary<string, Type>() { { "Name", "".GetType() }, { "Age", 1.GetType() } };
        table.Columns.Add(columns);
        var dict = table.GetDataTypes();
        Assert.Equal(columns, dict);
    }
}