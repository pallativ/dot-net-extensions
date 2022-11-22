// Copyright (c) VajraTechMinds.com. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Data;

namespace Primitive.Extensions;

public static class DataTableExtensions
{

    /// <summary>
    /// Gets the data table types.
    /// </summary>
    /// <param name="dataTable"></param>
    /// <returns>return <see cref="IDictionary{TKey,TValue}"/></returns>
    public static Dictionary<string, Type> GetDataTypes(this DataTable dataTable)
    {
        var dict = new Dictionary<string, Type>();
        for (int i = 0; i < dataTable.Columns.Count; i++)
        {
            var dataTableColumn = dataTable.Columns[i];
            dict.Add(dataTableColumn.ColumnName, dataTableColumn.DataType);
        }
        return dict;
    }
}
