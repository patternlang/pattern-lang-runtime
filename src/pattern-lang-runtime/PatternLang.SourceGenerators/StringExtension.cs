using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace PatternLang.SourceGenerators;

public static class StringExtension
{
    public static string NormalizeWhitespace(this string code) => CSharpSyntaxTree.ParseText(code).GetRoot().NormalizeWhitespace().ToFullString();
}