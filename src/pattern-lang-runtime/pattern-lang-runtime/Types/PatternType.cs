namespace PatternLang.Types;

public record PatternType(
        string Name,
        PatternNamespace Namespace,
        Type ClrType,
        IPatternType? SuperType = default,
        PatternDomain Domain = default)
    : IPatternType
{

}