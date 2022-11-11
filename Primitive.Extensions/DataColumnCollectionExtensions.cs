using System.Collections;
using System.Data;
using System.Linq;

namespace Primitive.Extensions;

public static class DataColumnCollectionExtensions
{
    /// <summary>
    /// Adds the columns to data table.
    /// </summary>
    /// <param name="dataColumnCollection"></param>
    /// <param name="columns"></param>
    public static void Add(this DataColumnCollection dataColumnCollection,
        IDictionary<string, Type> columns)
    {
        foreach (var column in columns)
        {
            dataColumnCollection.Add(column.Key, column.Value);
        }
    }

    /// <summary>
    /// Gets the list of column names.
    /// </summary>
    /// <param name="dataTable"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetColumnNames(this DataTable dataTable)
    {
        var columnNames = new List<string>();
        foreach (DataColumn dataTableColumn in dataTable.Columns)
        {
            columnNames.Add(dataTableColumn.ColumnName);
        }

        return columnNames;
    }
}