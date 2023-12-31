﻿using PatternLang.SourceGenerators.Tests.Helpers;
using Xunit;

namespace PatternLang.SourceGenerators.Tests;

public partial class PatternLangSourceGeneratorsGeneratorTests
{
    [Fact]
    public void Empty()
    {
        var userSource = @"";
        RunGenerator(userSource, out var generatorDiagnostics, out var generated);
        generatorDiagnostics.Verify();
        Assert.Single(generated);
        generated.ContainsFileWithContent("foo.cs", @"// <auto-generated/>
namespace PatternLang.SourceGenerators
{
    public class Foo
    {
    }
}");
    }
}
