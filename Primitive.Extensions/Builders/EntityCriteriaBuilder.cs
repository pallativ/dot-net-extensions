// Copyright (c) . All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions.Builders;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;

public class EntityCriteriaBuilder<T> : IEntityCriteriaBuilder<T>
    where T : class, new()
{
    private readonly IEntityCriteriaMapperFactory _entityCriteriaMapperFactory;
    private readonly ParameterExpression _parameterExpression;
    private readonly T _entity;

    public EntityCriteriaBuilder(IEntityCriteriaMapperFactory entityCriteriaMapperFactory)
    {
        _entityCriteriaMapperFactory = entityCriteriaMapperFactory;
        _entity = new();
        _parameterExpression = Expression.Parameter(_entity.GetType(), _entity.GetType().Name);
    }

    public Expression<Func<T, bool>> GetCriteria(IEnumerable<ConditionToken> conditionTokens)
    {
        var entityCriteriaMapper = _entityCriteriaMapperFactory.GetCriteriaMapper(_entity.GetType());
        var expressionCollection = CreateExpressionFrom(conditionTokens, entityCriteriaMapper);
        var finalExpression = CreateAndExpression(expressionCollection);
        if (finalExpression == null)
        {
            throw new Exception("Creating the expression");
        }

        return Expression.Lambda<Func<T, bool>>(finalExpression, _parameterExpression);
    }

    private static Expression CreateAndExpression(List<Expression> expressions)
    {
        Expression finalExpression = null!;
        expressions.ForEach(x =>
        {
            finalExpression = finalExpression == null ? x : Expression.AndAlso(x, finalExpression);
        });
        return finalExpression;
    }

    private List<Expression> CreateExpressionFrom(IEnumerable<ConditionToken> conditions, IEntityCriteriaMapper entityCriteriaMapper)
    {
        var expressions = new List<Expression>();
        foreach (var conditionToken in conditions)
        {
            try
            {
                var expression = BuildFilterExpression(conditionToken, entityCriteriaMapper);
                expressions.Add(expression);
            }
            catch (Exception)
            {
                // TODO Log Exception
            }
        }

        return expressions;
    }

    private Expression BuildFilterExpression(ConditionToken token, IEntityCriteriaMapper entityCriteriaMapper)
    {
        // Build Property. - This builds the left side of the where clause.
        Expression memberExpression = GetLeftOperand(token, entityCriteriaMapper, _parameterExpression);

        var value = ConvertTo(token.Value, memberExpression.Type);

        // Build the right side of the expression.
        ConstantExpression constant = GetRightOperand(value, memberExpression);

        switch (token.OperatorType)
        {
            case OperatorType.Equals:
                return Expression.Equal(memberExpression, constant);
            case OperatorType.NotEquals:
                return Expression.NotEqual(memberExpression, constant);
            case OperatorType.GreaterThen:
                return Expression.GreaterThan(memberExpression, constant);
            case OperatorType.LessThen:
                return Expression.LessThan(memberExpression, constant);
            case OperatorType.GreaterThenOrEqual:
                return Expression.GreaterThanOrEqual(memberExpression, constant);
            case OperatorType.LessThenOrEqual:
                return Expression.LessThanOrEqual(memberExpression, constant);
            case OperatorType.Range:
                return Expression.Equal(memberExpression, constant);
            default:
                break;
        }

        throw new Exception("Invalid expression");
    }

    private object ConvertTo(string value, Type type)
    {
        return type == typeof(DateTime) ? Convert.ToInt64(value).ToDateTime().ToString(CultureInfo.InvariantCulture) : value;
    }

    /// <summary>
    /// Gets the left Operand.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="entityCriteriaMapper"></param>
    /// <param name="parameterExpression"></param>
    /// <returns></returns>
    private static Expression GetLeftOperand(ConditionToken token, IEntityCriteriaMapper entityCriteriaMapper, ParameterExpression parameterExpression)
    {
        var entityFieldName = entityCriteriaMapper.GetEntityFieldPath(token.FieldName);
        return ExpressionBuilderBase.GetMemberExpression(entityFieldName, parameterExpression);
    }

    private static ConstantExpression GetRightOperand(object value, Expression memberExpression)
    {
        var propertyType = memberExpression.Type;
        var converter = TypeDescriptor.GetConverter(propertyType);
        if (!converter.CanConvertFrom(value.GetType()))
        {
            throw new NotSupportedException($"Unable to convert the value '{value}' to type {propertyType.Name}");
        }

        var propertyValue = converter.ConvertFrom(value);
        var constant = Expression.Constant(propertyValue);
        return constant;
    }
}
