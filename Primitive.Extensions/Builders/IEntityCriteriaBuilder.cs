using System.Linq.Expressions;

namespace Primitive.Extensions.Builders;

public interface IEntityCriteriaBuilder<T>
{
    Expression<Func<T, bool>> GetCriteria(IEnumerable<ConditionToken> conditionTokens);
}