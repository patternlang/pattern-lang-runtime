namespace PatternLang.SourceGenerators.Tests.Helpers;

internal struct VerifyDiagnosticAnalyzerResult
{
    public bool Success { get; private set; }

    public string ErrorMessage { get; private set; }

    public static VerifyDiagnosticAnalyzerResult Ok() => new VerifyDiagnosticAnalyzerResult { Success = true };

    public static VerifyDiagnosticAnalyzerResult Fail(string message) => new VerifyDiagnosticAnalyzerResult { Success = false, ErrorMessage = message };
}