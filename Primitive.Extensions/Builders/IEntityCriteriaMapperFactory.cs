namespace Primitive.Extensions.Builders;

public interface IEntityCriteriaMapperFactory
{
    IEntityCriteriaMapper GetCriteriaMapper(Type entityType);
}