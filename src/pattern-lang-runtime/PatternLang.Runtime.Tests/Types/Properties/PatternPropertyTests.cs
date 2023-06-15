// ReSharper disable BuiltInTypeReferenceStyle
#pragma warning disable CS8625
namespace PatternLang.Runtime.Tests.Types.Properties;

using TPropertyValue = System.String;
using System;
using Xunit;
using FluentAssertions;
using PatternLang.Types;
using PatternLang.Types.Properties;

public class PatternProperty_1Tests
{
    private readonly PatternProperty<TPropertyValue> _testClass;
    private readonly object?[] _args;

    public PatternProperty_1Tests()
    {
        _args = new object?[] { "Test", (PatternNamespace)"PatternLang.Tests", (PatternDomain)"Global", };
        _testClass = new PatternProperty<TPropertyValue>(_args);
    }

    [Fact]
    public void CanConstruct()
    {
        // Act
        var instance = new PatternProperty<TPropertyValue>(_args);

        // Assert
        instance.Should().NotBeNull();
    }

    [Fact]
    public void CannotConstructWithNullArgs()
    {
        FluentActions.Invoking(() => new PatternProperty<TPropertyValue>(null)).Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void CanCallGetDefault()
    {
        // Arrange
        var args = new[] { new object(), new object(), new object(),};

        // Act
        var result = _testClass.GetDefault(args);

        // Assert
        result.GetValue("Default")
            .Should()
            .BeNull();
    }

    [Fact]
    public void CannotCallGetDefaultWithNullArgs()
    {
        FluentActions.Invoking(() => _testClass.GetDefault(null)).Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void CanCallGetValue()
    {
        // Arrange
        var domain = new PatternDomain();

        // Act
        var result = _testClass.GetValue(domain);

        // Assert
        result.Some.Should()
            .NotBe(result.None);
        result.Value.Should()
            .NotBe(result.None);
        result.Should()
            .NotBe(result.None);
    }

    [Fact]
    public void CanCallSetValueWithPatternSafeValueOfTPropertyValueAndPatternDomain()
    {
        // Arrange
        var value = new PatternSafeValue<TPropertyValue>("TestValue703541787");
        var domain = new PatternDomain();

        // Act
        var result = _testClass.SetValue(value, domain);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    [Fact]
    public void CannotCallSetValueWithPatternSafeValueOfTPropertyValueAndPatternDomainWithNullValue()
    {
        FluentActions.Invoking(() => _testClass.SetValue(default(PatternSafeValue<TPropertyValue>), new PatternDomain())).Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void SetValueWithPatternSafeValueOfTPropertyValueAndPatternDomainPerformsMapping()
    {
        // Arrange
        var value = new PatternSafeValue<TPropertyValue>("TestValue1157437061");
        var domain = new PatternDomain();

        // Act
        var result = _testClass.SetValue(value, domain);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    [Fact]
    public void CanCallSetValueWithTPropertyValueAndPatternDomain()
    {
        // Arrange
        var value = "TestValue91705997";
        var domain = new PatternDomain();

        // Act
        var result = _testClass.SetValue(value, domain);

        // Assert
        throw new NotImplementedException("Create or modify test");
    }

    [Fact]
    public void SetValueWithTPropertyValueAndPatternDomainPerformsMapping()
    {
        // Arrange
        var value = "TestValue227264843";
        var domain = new PatternDomain();

        // Act
        var result = _testClass.SetValue(value, domain);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

}