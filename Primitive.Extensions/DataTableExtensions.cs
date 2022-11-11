using System.Data;

namespace Primitive.Extensions;

public static class DataTableExtensions {
    public static void AddRow(this DataTable dataTable, object[] record)
    {
        dataTable.Rows.Add(record);
    }
}