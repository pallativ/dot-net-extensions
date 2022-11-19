namespace Primitive.Extensions.Builders;

public class ConditionToken
{
    public ConditionToken(string fieldName, OperatorType type, string value)
    {
        FieldName = fieldName;
        OperatorType = type;
        Value = value;
    }
    public string FieldName { get; set; }
    public OperatorType OperatorType { get; set; }
    public string Value { get; set; }

}