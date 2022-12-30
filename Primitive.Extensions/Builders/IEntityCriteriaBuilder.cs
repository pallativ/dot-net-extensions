// Copyright (c) . All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions.Builders;
using System.Linq.Expressions;

/// <summary>
/// IEntityCriteriaBuilder type.
/// </summary>
/// <typeparam name="T">Entity type</typeparam>
public interface IEntityCriteriaBuilder<T>
{
    Expression<Func<T, bool>> GetCriteria(IEnumerable<ConditionToken> conditionTokens);
}
