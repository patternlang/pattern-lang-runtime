namespace PatternLang.Types;

using Members;

using Properties;

public record PatternObjectBaseType(
        string Name,
        PatternNamespace Namespace,
        Type ClrType,
        IPatternType? SuperType = default,
        PatternDomain Domain = default
    )
    : PatternType(Name, Namespace, ClrType, SuperType, Domain)
{
    public PatternObjectBaseType() : this(
        nameof(PatternObjectBase),
        new("PatternLang"),
        typeof(PatternObjectBase),
        default,
        default
    )
    { }

    public static TDefinitionType GetDefault<TDefinitionType>(params object?[]? args)
        where TDefinitionType : IPatternType
        => (TDefinitionType)Activator.CreateInstance(typeof(TDefinitionType), args)!;

    public static IPatternObject GetDefault(PatternType type, params object?[]? args)
        => (IPatternObject)Activator.CreateInstance(type.ClrType, args)!;

    public static object GetDefault(Type type, params object?[]? args)
        => Activator.CreateInstance(type, args)!;

    public override string ToString()
        => $"{Namespace.FullName}.{Name}::{Domain.FullName}";

    protected List<PatternMember> Members { get; } = new();
    protected List<PatternProperty> Properties { get; } = new();
}