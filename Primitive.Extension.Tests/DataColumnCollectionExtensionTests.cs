using System.Data;
using Primitive.Extensions;
namespace Primitive.Extension.Tests;

public class DataColumnCollectionExtensionTests
{
    [Fact]
    public void Verify_Adding_Multiple_Columns()
    {
        var table = new DataTable("Sample");
        var columns = new Dictionary<string, Type>
        {
            { "Name", "".GetType() },
            { "Age", 1.GetType() }
        };
        table.Columns.Add(columns);
        Assert.Equal(2, table.Columns.Count);
        Assert.Equal("Name", table.Columns[0].ColumnName);
        Assert.Equal("Age", table.Columns[1].ColumnName);
        Assert.Equal(new List<string>{"Name", "Age"}, table.GetColumnNames());
    }
}