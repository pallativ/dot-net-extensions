// Copyright (c) VajraTechMinds.com. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Linq.Expressions;

namespace Primitive.Extensions.Builders;

public interface IEntityCriteriaBuilder<T>
{
    Expression<Func<T, bool>> GetCriteria(IEnumerable<ConditionToken> conditionTokens);
}
