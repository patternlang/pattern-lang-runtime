namespace PatternLang.Types;

public record struct PatternDomain(string? FullName = "Global")
{
    public override string ToString()
        => $"{FullName ?? "Global"}";

    public static PatternDomain DEFAULT { get; } = new();

    public static implicit operator string(PatternDomain domain)
        => domain.FullName ?? "Global";

    public static implicit operator PatternDomain(string domain)
        => new(domain);
}