namespace PatternLang.Runtime.Tests;

public abstract class TestBase
{
    protected readonly PatternNamespace _namespace = "PatternLang.Runtime.Tests";
    protected readonly PatternDomain _domain = "UnitTests";


    public ITestOutputHelper OutputHelper
    {
        get;
    }

    protected TestBase(ITestOutputHelper outputHelper) => OutputHelper = outputHelper;
}