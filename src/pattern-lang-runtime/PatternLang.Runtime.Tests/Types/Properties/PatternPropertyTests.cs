// ReSharper disable BuiltInTypeReferenceStyle

using TPropertyValue = PatternLang.Types.PatternString.PatternStringType;
using System;
using Xunit;
using FluentAssertions;
using PatternLang.Types;
using PatternLang.Types.Properties;

#pragma warning disable CS8625
namespace PatternLang.Runtime.Tests.Types.Properties;
public class PatternPropertyTests
{
    private readonly PatternDomain _domain = (PatternDomain)"Global";
    private readonly PatternNamespace _ns = (PatternNamespace)"PatternLang.Tests";
    private readonly PatternProperty<TPropertyValue, string> _testClass;
    private readonly object?[] _args;

    public PatternPropertyTests()
    {
        _args = new object?[] { "Test", _ns, _domain, };
        _testClass = new PatternProperty<TPropertyValue, string>(_args);
    }

    [Fact]
    public void CanConstruct()
    {
        // Act
        var instance = new PatternProperty<TPropertyValue, string>(_args);

        // Assert
        instance.Should().NotBeNull();
    }

    [Fact]
    public void CannotConstructWithNullArgs()
        => FluentActions.Invoking(()
            => new PatternProperty<TPropertyValue, string>(null)).Should().Throw<ArgumentNullException>();

    [Fact]
    public void CanCallGetDefault()
    {
        // Arrange
        var args = new[] { new object(), _ns, _domain, };

        // Act
        var result = _testClass.GetDefault(args);

        // Assert
        string? value = result.GetValue(_domain);

        value
            .Should()
            .BeNull();
    }

    [Fact]
    public void CannotCallGetDefaultWithNullArgs() => FluentActions.Invoking(() => _testClass.GetDefault(null)).Should().Throw<ArgumentNullException>();

    [Fact]
    public void CanCallGetValue()
    {
        // Arrange
        var domain = new PatternDomain();

        // Act
        var result = _testClass.GetValue(domain);

        // Assert
        result.Some.Should()
            .BeTrue();
        result.Value.Should()
            .NotBe(result.None);
        result.Should()
            .NotBe(result.None);
    }

    [Fact]
    public void CanCallSetValueWithPatternSafeValueOfTPropertyValueAndPatternDomain()
    {
        const string V = "TestValue703541787";
        // Arrange
        var value = new PatternSafeValue<string>(V);
        var domain = new PatternDomain();

        // Act
        string? result = _testClass.SetValue(value, domain);

        // Assert
        result.Should().NotBeNull().And.Be(V);
    }

    [Fact]
    public void CallSetValueWithDefaultValueAndPatternDomainWithUnknownValue()
        => _testClass.SetValue(
                default(string),
                "Unknown")
                .Should()
                .Be(_testClass.Value.None);

    [Fact]
    public void CallSetValueWithDefaultPatternSafeValueOfTPropertyValueAndPatternDomainWithUnknownValue()
        => _testClass.SetValue(
                default(PatternSafeValue<string>),
                "Unknown")
                .Should()
                .Be(_testClass.Value.None);

    [Fact]
    public void SetValueWithPatternSafeValueOfTPropertyValueAndPatternDomainPerformsMapping()
    {
        // Arrange
        var value = new PatternSafeValue<string>("TestValue1157437061");
        var domain = new PatternDomain();

        // Act
        PatternSafeValue<string> result = _testClass.SetValue(value, domain);

        // Assert
        result.Value.Should().BeSameAs(value.Value);
    }

    [Fact]
    public void CanCallSetValueWithTPropertyValueAndPatternDomain()
    {
        // Arrange
        const string V = "TestValue91705997";
        var domain = new PatternDomain();

        // Act
        string? result = _testClass.SetValue(V, domain);

        // Assert
        result.Should().NotBeNull().And.Be(V);
    }

    [Fact]
    public void SetValueWithTPropertyValueAndPatternDomainPerformsMapping()
    {
        // Arrange
        var value = "TestValue227264843";
        var domain = new PatternDomain();

        // Act
        PatternSafeValue<string> result = _testClass.SetValue(value, domain);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

}