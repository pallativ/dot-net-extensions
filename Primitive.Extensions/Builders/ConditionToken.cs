// Copyright (c) VajraTechMinds.com. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions.Builders;

/// <summary>
/// Defines the ConditionToken type.
/// </summary>
public class ConditionToken
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConditionToken"/> class.
    /// </summary>
    /// <param name="fieldName">Field Name</param>
    /// <param name="type">Operator type <see cref="OperatorType"/></param>
    /// <param name="value">value of the right hand operand.</param>
    public ConditionToken(string fieldName, OperatorType type, string value)
    {
        FieldName = fieldName;
        OperatorType = type;
        Value = value;
    }

    /// <summary>
    /// Gets or sets field Name.
    /// </summary>
    public string FieldName { get; set; }

    /// <summary>
    /// Gets or sets OperatorType.
    /// </summary>
    public OperatorType OperatorType { get; set; }

    /// <summary>
    /// Gets or sets Value.
    /// </summary>
    public string Value { get; set; }

}