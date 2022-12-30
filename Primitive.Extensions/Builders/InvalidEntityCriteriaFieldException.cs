// Copyright (c) . All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions.Builders;
using System.Runtime.Serialization;

/// <summary>
/// Defines InvalidEntityCriteriaFieldException type.
/// </summary>
[Serializable]
public class InvalidEntityCriteriaFieldException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidEntityCriteriaFieldException"/> class.
    /// </summary>
    public InvalidEntityCriteriaFieldException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidEntityCriteriaFieldException"/> class.
    /// </summary>
    /// <param name="message">Exception message</param>
    public InvalidEntityCriteriaFieldException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidEntityCriteriaFieldException"/> class.
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="innerException">inner exception.</param>
    public InvalidEntityCriteriaFieldException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidEntityCriteriaFieldException"/> class.
    /// </summary>
    /// <param name="info">Information <see cref="SerializationInfo"/></param>
    /// <param name="context">StreamContext <see cref="StreamingContext"/></param>
    protected InvalidEntityCriteriaFieldException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
