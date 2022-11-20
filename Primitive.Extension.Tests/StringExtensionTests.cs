using System.ComponentModel;
using System.Diagnostics.Metrics;
using Primitive.Extensions;
using Primitive.Extensions.Builders;

namespace Primitive.Extension.Tests;

public class StringExtensionTests
{
    internal enum Name
    {
        FirstName,
        LastName
    }

    [Fact]
    public void VerifyStringConversionToEnum()
    {
        var actualResult = "FirstName".ToEnum<Name>();
        Assert.Equal(Name.FirstName, actualResult);
        actualResult = "LastName".ToEnum<Name>();
        Assert.Equal(Name.LastName, actualResult);
    }

    [Fact]
    public void VerifyExceptionWhenInvalidValueIsUsed()
    {
        Assert.Throws<ArgumentException>(() => "FirstName1".ToEnum<Name>());
    }
}

public class EnumExtensionTests
{
    internal enum Name
    {
        [Description("First Name")]
        FirstName,
        [Description("Last Name")]
        LastName,
        FullName
    }
    [Fact]
    public void VerifyGetAttribute()
    {
        var description = Name.FirstName.GetDescription();
        Assert.NotNull(description);
        Assert.Equal("First Name", description);
        var attribute = Name.FirstName.GetAttribute<DescriptionAttribute>();
        Assert.NotNull(attribute);
    }
}

public class EntityCriteriaBuilderTests
{
    public class Person
    {
        public string? FirstName { get; set; }
    }

    public class MockEntityCriteriaMapper : IEntityCriteriaMapper
    {
        public string GetEntityFieldPath(string fieldName)
        {
            switch (fieldName)
            {
                case "FirstName":
                    return "FirstName";
            }

            return string.Empty;
        }

        public bool IsExists(string fieldName)
        {
            throw new NotImplementedException();
        }
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
        var entityCriteriaBuilder = new EntityCriteriaBuilder<Person>(new MockEntityCriteriaMapperFactory());
        var conditionTokens = new List<ConditionToken>()
        {
            new ConditionToken("FirstName", OperatorType.Equals, "Veera")
        };
        var result = entityCriteriaBuilder.GetCriteria(conditionTokens);
        Assert.NotNull(result);
        Assert.Equal($"Person => (Person.FirstName == \"Veera\")", result.ToString());
    }
}