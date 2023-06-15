namespace PatternLang.Runtime.Tests.Types;

public record TestDefinition(IPatternType? SuperType, PatternNamespace Namespace, PatternDomain Domain,
    string Name
) : IPatternType
{
    public override string ToString()
        => $"{Namespace.FullName}.{Name}::{Domain.FullName ?? "Global"}";

    public Type? ClrType
    {
        get;
        set;
    }
}
