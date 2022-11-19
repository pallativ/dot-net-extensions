using System.Linq.Expressions;

namespace Primitive.Extensions.Builders;

internal class ExpressionBuilderBase
{
    public static Expression GetMemberExpression(string entityFieldName, ParameterExpression parameterExpression)
    {
        if (entityFieldName == null)
            throw new ArgumentNullException(nameof(entityFieldName));
        Expression memberExpression = parameterExpression;
        foreach (var member in entityFieldName.Split('.'))
        {
            memberExpression = Expression.PropertyOrField(memberExpression, member);
        }
        return memberExpression;
    }
}