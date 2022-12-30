// Copyright (c) . All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extension.Tests;
using System.Globalization;
using Extensions;
using Extensions.Builders;

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
        /// <inheritdoc/>
        protected override IDictionary<string, string> FieldsMapping { get; set; } = new Dictionary<string, string>()
        {
            { "FirstName", "FirstName" },
            { "Age", "Age" },
            { "Dob", "Dob" },
        };
    }

    [Fact]
    public void VerifySingleFieldCriteria()
    {
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
        var entityCriteriaBuilder = new EntityCriteriaBuilder<Person>(new MockEntityCriteriaMapperFactory());
        var conditionTokens = new List<ConditionToken>()
        {
            new ("FirstName", OperatorType.Equals, "Veera"),
            new ("Age", OperatorType.GreaterThen, 18.ToString()),
            new ("Dob", OperatorType.GreaterThen, new DateTime(2020, 1, 1).ToEpochTime().ToString(CultureInfo.InvariantCulture)),
        };
        var result = entityCriteriaBuilder.GetCriteria(conditionTokens);
        Assert.NotNull(result);
        Assert.Equal($"Person => ((Person.Dob > 1/1/2020 12:00:00 AM) AndAlso ((Person.Age > 18) AndAlso (Person.FirstName == \"Veera\")))", result.ToString());
    }
}