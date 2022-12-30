// Copyright (c) . All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions;
using System.Data;

/// <summary>
/// Data Column Collection extensions
/// </summary>
public static class DataColumnCollectionExtensions
{
    /// <summary>
    /// Adds the columns to data table.
    /// </summary>
    /// <param name="dataColumnCollection">Data Column Collection</param>
    /// <param name="columns">Columns names to be added</param>
    public static void Add(
        this DataColumnCollection dataColumnCollection,
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
    /// <param name="dataTable">DataTable</param>
    /// <returns>Returns the column names</returns>
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
