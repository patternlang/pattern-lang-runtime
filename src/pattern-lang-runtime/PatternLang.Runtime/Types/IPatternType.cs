namespace PatternLang.Types;

public interface IPatternType
{
    IPatternType? SuperType { get; }
    Type? ClrType { get; }
    PatternNamespace Namespace { get; }
    PatternDomain Domain { get; }
    string Name { get; }
}