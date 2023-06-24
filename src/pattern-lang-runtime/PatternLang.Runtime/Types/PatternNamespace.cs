using System.Xml.Linq;

namespace PatternLang.Types;

public record struct PatternNamespace(string? FullName = "PatternLang")
{
    public override string ToString()
        => $"{FullName ?? "PatternLang"}";

    public static PatternNamespace DEFAULT { get; } = new();

    public static implicit operator string(PatternNamespace @namespace)
        => @namespace.FullName ?? "PatternLang";

    public static implicit operator PatternNamespace(string @namespace)
        => new(@namespace);
}