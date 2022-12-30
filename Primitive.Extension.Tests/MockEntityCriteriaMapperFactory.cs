// Copyright (c) . All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extension.Tests;
using Primitive.Extensions.Builders;

/// <summary>
/// Entity Criteria Mapper Factory.
/// </summary>
public class MockEntityCriteriaMapperFactory : IEntityCriteriaMapperFactory
{
    /// <summary>
    /// Gets the Criteria mapper.
    /// </summary>
    /// <param name="entityType">EntityType.</param>
    /// <returns>Returns the <see cref="IEntityCriteriaMapper"/>.</returns>
    public IEntityCriteriaMapper GetCriteriaMapper(Type entityType)
    {
        return new EntityCriteriaBuilderTests.MockEntityCriteriaMapper();
    }
}
