using NSubstitute;

using PatternLang.Types;

using System;

using Xunit;

namespace PatternLang.Runtime.Tests.Types
{
    using System.Reflection;

    public class PatternObjectBaseTypeTests : TestBase
    {


        public PatternObjectBaseTypeTests(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {

        }

        [Fact]
        public void GetDefault_StateUnderTest_ExpectedBehavior()
        {
            string methodName = MethodBase.GetCurrentMethod()!.Name;

            // Arrange
            var args = new object?[]
            {
                (IPatternType?)null,
                _namespace,
                _domain,
                nameof(TestDefinition),
            };


            // Act
            TestDefinition result = PatternObjectBaseType.GetDefault<TestDefinition>(args);

            // Assert
            result.Should().NotBeNull();

            OutputHelper.WriteLine($"{methodName}: Created Default instance: {result}");
        }
    }
}
