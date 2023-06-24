using NSubstitute;

using PatternLang.Types;

using System;

using Xunit;

using System.Reflection;

namespace PatternLang.Runtime.Tests.Types;
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
            _namespace,
            _domain,
        };


        // Act
        TestDefinition result = 
            PatternObjectBaseType<PatternString.PatternStringType, string>
                .GetDefault<TestDefinition>(args);

        // Assert
        result.Should().NotBeNull();

        OutputHelper.WriteLine($"{methodName}: Created Default instance: {result}");
    }
}
