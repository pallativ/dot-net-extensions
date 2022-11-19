using System.Runtime.Serialization;

namespace Primitive.Extensions.Builders;

[Serializable]
public class InvalidEntityCriteriaFieldException : Exception
{
    public InvalidEntityCriteriaFieldException()
    {
    }

    public InvalidEntityCriteriaFieldException(string message) : base(message)
    {
    }

    public InvalidEntityCriteriaFieldException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected InvalidEntityCriteriaFieldException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}