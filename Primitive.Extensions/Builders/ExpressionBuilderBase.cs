// Copyright (c) VajraTechMinds.com. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions.Builders;
using System.Linq.Expressions;

/// <summary>
/// Defines the Expression Builder Base.
/// </summary>
internal class ExpressionBuilderBase
{
    /// <summary>
    /// Builds expression using parameter expression and entityFieldName.
    /// </summary>
    /// <param name="entityFieldName">EntityFieldName</param>
    /// <param name="parameterExpression">Parameter Expression</param>
    /// <returns>Returns Expression</returns>
    /// <exception cref="ArgumentNullException">Throws exception when entityFieldName is null</exception>
    public static Expression GetMemberExpression(string entityFieldName, ParameterExpression parameterExpression)
    {
        if (entityFieldName == null)
        {
            throw new ArgumentNullException(nameof(entityFieldName));
        }

        Expression memberExpression = parameterExpression;
        foreach (var member in entityFieldName.Split('.'))
        {
            memberExpression = Expression.PropertyOrField(memberExpression, member);
        }

        return memberExpression;
    }
}