// Copyright (c) VajraTechMinds.com. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions.Builders;

public interface IEntityCriteriaMapper
{
    /// <summary>
    /// Gets the entity field mapping using field name
    /// </summary>
    /// <param name="fieldName">Field Name</param>
    /// <returns>returns Entity Field Name</returns>
    string GetEntityFieldPath(string fieldName);

    /// <summary>
    /// Checks whether the field name is configured.
    /// </summary>
    /// <param name="fieldName">Field Name</param>
    /// <returns>Returns boolean</returns>
    bool IsExists(string fieldName);
}