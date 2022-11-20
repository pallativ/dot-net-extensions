using System.Globalization;
using Primitive.Extensions;
using Primitive.Extensions.Builders;

namespace Primitive.Extension.Tests;

public class EntityCriteriaBuilderTests
{
    public class Person
    {
        public string? FirstName { get; set; }
        public int Age { get; set; }
        public DateTime Dob { get; set; }
    }

    public class MockEntityCriteriaMapper : BaseEntityCriteriaMapper
    {
        protected override IDictionary<string, string> FieldsMapping { get; set; } = new Dictionary<string, string>()
        {
            {"FirstName","FirstName"},
            {"Age","Age"},
            {"Dob","Dob"},
        };
    }

    public class MockEntityCriteriaMapperFactory : IEntityCriteriaMapperFactory
    {
        public IEntityCriteriaMapper GetCriteriaMapper(Type entityType)
        {
            return new MockEntityCriteriaMapper();
        }
    }

    [Fact]
    public void VerifySingleFieldCriteria()
    {
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
        var entityCriteriaBuilder = new EntityCriteriaBuilder<Person>(new MockEntityCriteriaMapperFactory());
        var conditionTokens = new List<ConditionToken>()
        {
            new("FirstName", OperatorType.Equals, "Veera"),
            new("Age", OperatorType.GreaterThen, 18.ToString()),
            new("Dob", OperatorType.GreaterThen, new DateTime(2020,1,1).ToEpochTime().ToString(CultureInfo.InvariantCulture)),
        };
        var result = entityCriteriaBuilder.GetCriteria(conditionTokens);
        Assert.NotNull(result);
        Assert.Equal($"Person => ((Person.Dob > 1/1/2020 12:00:00 AM) AndAlso ((Person.Age > 18) AndAlso (Person.FirstName == \"Veera\")))", result.ToString());
    }
}