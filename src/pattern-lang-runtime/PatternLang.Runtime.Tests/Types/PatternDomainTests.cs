namespace PatternLang.Runtime.Tests.Types
{
    using System;
    using Xunit;
    using FluentAssertions;
    using PatternLang.Types;
    using System.Reflection;

    public class PatternDomainTests : TestBase
    {
        private PatternDomain _testClass;
        private string _fullName;

        public PatternDomainTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            _fullName = "UnitTests";
            _testClass = new PatternDomain(_fullName);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new PatternDomain(_fullName);

            // Assert
            instance.Should().NotBeNull();

            OutputHelper.WriteLine($"Correctly initialized new PatternDomain: {instance}");
        }

        [Fact]
        public void ImplementsIEquatable_PatternDomain()
        {
            // Arrange
            var same = new PatternDomain(_fullName);
            var different = new PatternDomain();

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
}