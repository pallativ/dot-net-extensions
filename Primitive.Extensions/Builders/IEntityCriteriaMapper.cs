namespace Primitive.Extensions.Builders;

public interface IEntityCriteriaMapper
{
    string GetEntityFieldPath(string fieldName);
    bool IsExists(string fieldName);
}