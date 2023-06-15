#pragma warning disable CS8625
namespace PatternLang.Runtime.Tests.Types;

using System.Reflection;

using FluentAssertions.Specialized;
using PatternLang.Types.Members;
using PatternLang.Types.Properties;

public class PatternObjectSubclass : PatternObjectBase
{
    public override string ToString()
        => base.ToString() ?? GetType().FullName ?? GetType().Name;

    public override PatternObjectBase GetDefault(params object?[] args)
        => throw new NotImplementedException();
}

public class PatternObjectBaseTests : TestBase
{
    private readonly PatternObjectBase _testClass;
    private readonly PatternObjectBaseType _patternType;

    public PatternObjectBaseTests(ITestOutputHelper outputHelper): base(outputHelper)
    {
        _patternType = new PatternObjectBaseType
        {
            Domain = _domain,
            Namespace = _namespace,
        };

        _testClass = new PatternObjectSubclass
            { PatternType = _patternType, };
    }

    [Fact]
    public void CanInitialize()
    {
        // Act
        var instance = new PatternObjectSubclass
            { PatternType = _patternType,};

        // Assert
        instance.Should().NotBeNull();

        OutputHelper.WriteLine($"Correctly initialized new PatternObjectSubclass: {instance}");
    }

    [Fact]
    public void CannotInitializeWithNullPatternType()
    {
        ExceptionAssertions<ArgumentNullException>? result = FluentActions.Invoking(
            static () => new PatternObjectSubclass
        {
            PatternType = default,
        }).Should().Throw<ArgumentNullException>();

        OutputHelper.WriteLine($"Correctly threw ArgumentNullException: {result}.");
    }

    [Fact]
    public void PatternTypeIsInitializedCorrectly()
    {
        _testClass.PatternType.Should().BeSameAs(_patternType);

        OutputHelper.WriteLine($"{MethodBase.GetCurrentMethod()!.Name}: {_testClass.PatternType}");
    }
}