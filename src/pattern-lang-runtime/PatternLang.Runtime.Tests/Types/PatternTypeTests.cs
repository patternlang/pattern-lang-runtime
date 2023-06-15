// ReSharper disable FieldCanBeMadeReadOnly.Local
namespace PatternLang.Runtime.Tests.Types;

public class PatternTypeTests
{
    private PatternType _testClass;
    private Type _clrType;
    private string _name;
    private PatternNamespace _namespace;
    private IPatternType _superType;
    private PatternDomain _domain;

    public PatternTypeTests()
    {
        _name = "TestValue1541117588";
        _namespace = new PatternNamespace();
        _superType = Substitute.For<IPatternType>();
        _clrType = typeof(IPatternType);
        _domain = new PatternDomain();
        _testClass = new PatternType(_name, _namespace, _clrType, _superType, _domain);
    }

    [Fact]
    public void CanConstruct()
    {
        // Act
        var instance = new PatternType(_name, _namespace, _clrType, _superType, _domain);

        // Assert
        instance.Should().NotBeNull();
    }

    [Fact]
    public void ImplementsIEquatable_PatternType()
    {
        // Arrange
        var same = new PatternType(_name, _namespace, _clrType, _superType, _domain);
        var different = new PatternType(
            "TestValue1266645959",
            new PatternNamespace(),
            typeof(IPatternType),
            Substitute.For<IPatternType>(),
            new PatternDomain());

        // Assert
        _testClass.Equals(default(object)).Should().BeFalse();
        _testClass.Equals(new object()).Should().BeFalse();
        _testClass.Equals((object)same).Should().BeTrue();
        _testClass.Equals((object)different).Should().BeFalse();
        _testClass.Equals(same).Should().BeTrue();
        _testClass.Equals(different).Should().BeFalse();
        _testClass.GetHashCode().Should().Be(same.GetHashCode());
        _testClass.GetHashCode().Should().NotBe(different.GetHashCode());
        (_testClass == same).Should().BeTrue();
        (_testClass == different).Should().BeFalse();
        (_testClass != same).Should().BeFalse();
        (_testClass != different).Should().BeTrue();
    }

    [Fact]
    public void NameIsInitializedCorrectly()
    {
        _testClass.Name.Should().Be(_name);
    }

    [Fact]
    public void NamespaceIsInitializedCorrectly()
    {
        _testClass.Namespace.Should().Be(_namespace);
    }

    [Fact]
    public void SuperTypeIsInitializedCorrectly()
    {
        _testClass.SuperType.Should().BeSameAs(_superType);
    }

    [Fact]
    public void DomainIsInitializedCorrectly()
    {
        _testClass.Domain.Should().Be(_domain);
    }
}