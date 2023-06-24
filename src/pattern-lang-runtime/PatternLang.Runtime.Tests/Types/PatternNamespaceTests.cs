
using System;
using System.Reflection;

using Xunit;
using FluentAssertions;
using PatternLang.Types;

namespace PatternLang.Runtime.Tests.Types;
public class PatternNamespaceTests :TestBase
{
    private PatternNamespace _testClass;
    private string _fullName;

    public PatternNamespaceTests(ITestOutputHelper oh):base(oh)
    {
        _fullName = "PatternLang.Runtime.Tests";
        _testClass = new PatternNamespace(_fullName);
    }

    [Fact]
    public void CanConstruct()
    {
        // Act
        var instance = new PatternNamespace(_fullName);

        // Assert
        instance.Should().NotBeNull();

        OutputHelper.WriteLine($"Correctly initialized new PatternNamespace: {instance}");
    }

    [Fact]
    public void ImplementsIEquatable_PatternNamespace()
    {
        // Arrange
        var same = new PatternNamespace(_fullName);
        var different = new PatternNamespace();

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

        OutputHelper.WriteLine($"Correctly implements IEquatable.");
    }

    [Fact]
    public void FullNameIsInitializedCorrectly()
    {
        _testClass.FullName.Should().Be(_fullName);

        OutputHelper.WriteLine($"{MethodBase.GetCurrentMethod()!.Name}: {_testClass.FullName}");
    }
}