// Copyright (c) VajraTechMinds.com. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions.Builders;

/// <summary>
/// Defines BaseEntityCriteriaMapper type.
/// </summary>
public abstract class BaseEntityCriteriaMapper : IEntityCriteriaMapper
{
    /// <summary>
    /// Gets or sets contains the fields and entity fields mapping.
    /// </summary>
    protected abstract IDictionary<string, string> FieldsMapping { get; set; }

    /// <inheritdoc/>
    public string GetEntityFieldPath(string fieldName)
    {
        if (IsExists(fieldName))
        {
            return GetMappedFieldName(fieldName);
        }

        throw new InvalidEntityCriteriaFieldException();
    }

    /// <inheritdoc/>
    public bool IsExists(string fieldName)
    {
        return FieldsMapping.ToList().Any(t => t.Key.ToUpper().Equals(fieldName.ToUpper()));
    }

    private string GetMappedFieldName(string fieldName)
    {
        var keyValuePair = FieldsMapping.ToList().First(t => t.Key.ToUpper().Equals(fieldName.ToUpper()));
        return keyValuePair.Value;
    }
}
