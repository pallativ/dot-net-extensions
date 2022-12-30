// Copyright (c) . All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions.Builders;

public interface IEntityCriteriaMapperFactory
{
    IEntityCriteriaMapper GetCriteriaMapper(Type entityType);
}
