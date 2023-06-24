
using System.Reflection;

using FluentAssertions.Specialized;

using Newtonsoft.Json.Linq;

using PatternLang.Types.Members;
using PatternLang.Types.Properties;

using static PatternLang.Types.PatternInteger;

#pragma warning disable CS8625
namespace PatternLang.Runtime.Tests.Types;
public class PatternObjectSubclass<TPatternType, TClrType> 
    : PatternObjectBase<TPatternType, TClrType>
    where TPatternType : PatternObjectBaseType<TPatternType, TClrType>, IPatternObject
{
    public PatternObjectSubclass() : base() { }

    private PatternObjectSubclass(PatternNamespace @namespace, PatternDomain domain) 
        : base(@namespace, domain) { }

    private PatternObjectSubclass<TPatternType, TClrType>? _protectedDefault = null;
    protected override PatternObjectBase<TPatternType, TClrType> ProtectedDefault
        => _protectedDefault ??= new PatternObjectSubclass<TPatternType, TClrType>();

    public override string ToString()
        => base.ToString() ?? GetType().FullName ?? GetType().Name;

    public override PatternObjectBase<TPatternType, TClrType> GetDefault(params object?[] args)
        => new PatternObjectSubclass<TPatternType, TClrType>(
            args.OfType<PatternNamespace>().FirstOrDefault(PatternNamespace.DEFAULT),
            args.OfType<PatternDomain>().FirstOrDefault(PatternDomain.DEFAULT)
            );
}

public class PatternObjectBaseTests : TestBase
{
    private readonly PatternString _testClass;
    private readonly PatternString.PatternStringType _patternType;

    public PatternObjectBaseTests(ITestOutputHelper outputHelper): base(outputHelper)
    {
        _patternType = 
            new PatternString.PatternStringType(_namespace, _domain);

        _testClass = new PatternString(nameof(PatternObjectBaseTests), _namespace, _domain)
        { PatternType = _patternType, };
    }

    [Fact]
    public void CanInitialize()
    {
        // Act
        var instance = new PatternObjectSubclass<PatternString.PatternStringType, string>
            { PatternType = _patternType,};

        // Assert
        instance.Should().NotBeNull();

        OutputHelper.WriteLine($"Correctly initialized new PatternObjectSubclass: {instance}");
    }

    [Fact]
    public void CannotInitializeWithNullPatternType()
    {
        ExceptionAssertions<ArgumentNullException>? result = FluentActions.Invoking(
            static () => new PatternObjectSubclass<PatternString.PatternStringType, string>
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