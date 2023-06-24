﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace PatternLang.SourceGenerators;

internal static class SourceGeneratorContextExtension
{
    public static void AddCode(this GeneratorExecutionContext context, string hint_name, string code) 
        => context.AddSource(
            hint_name
                .Replace("<", "_")
                .Replace(">", "_"), 
            SourceText.From(
                code.NormalizeWhitespace(), 
                Encoding.UTF8)
            );
}