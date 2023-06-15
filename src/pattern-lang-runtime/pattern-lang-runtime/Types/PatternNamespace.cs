using System.Xml.Linq;

namespace PatternLang.Types;

public record struct PatternNamespace(string? FullName = "Global")
{
    public override string ToString()
        => $"{FullName ?? "Global"}";

    public static PatternNamespace DEFAULT { get; } = new();

    public static implicit operator string(PatternNamespace @namespace)
        => @namespace.FullName ?? "Global";

    public static implicit operator PatternNamespace(string @namespace)
        => new(@namespace);
}