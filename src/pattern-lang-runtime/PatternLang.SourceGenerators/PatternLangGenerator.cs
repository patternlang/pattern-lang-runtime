﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace PatternLang.SourceGenerators;

[Generator]
public partial class PatternLangGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context) =>
        // Register a syntax receiver that will be created for each generation pass
        context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());

    public void Execute(GeneratorExecutionContext context)
    {
        if (context.SyntaxReceiver is not SyntaxReceiver receiver)
        {
            return;
        }

        context.AddCode("foo.cs", @"// <auto-generated/>
namespace PatternLang.SourceGenerators
{
    public class Foo
    {
    }
}");
    }

    /// <summary>
    /// Created on demand before each generation pass
    /// </summary>
    internal class SyntaxReceiver : ISyntaxReceiver
    {
        public List<ClassDeclarationSyntax> CandidateClasses { get; } = new List<ClassDeclarationSyntax>();

        /// <summary>
        /// Called for every syntax node in the compilation, we can inspect the nodes and save any information useful for generation
        /// </summary>
        public void OnVisitSyntaxNode(SyntaxNode syntax_node)
        {
            // any class with at least one attribute is a candidate for property generation
            if (syntax_node is ClassDeclarationSyntax classDeclarationSyntax)
            {
                CandidateClasses.Add(classDeclarationSyntax);
            }
        }
    }
}