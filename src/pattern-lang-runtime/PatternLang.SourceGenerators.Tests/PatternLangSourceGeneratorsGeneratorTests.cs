using PatternLang.SourceGenerators;
using PatternLang.SourceGenerators.Tests.Helpers;
using Xunit.Abstractions;

namespace PatternLang.SourceGenerators.Tests;

public partial class PatternLangSourceGeneratorsGeneratorTests : TestBase<PatternLangGenerator>
{
    public PatternLangSourceGeneratorsGeneratorTests(ITestOutputHelper output_helper) : base(output_helper)
    {
    }
    // for the actual test cases, see folder "PatternLang.SourceGeneratorsGenerator"
}
