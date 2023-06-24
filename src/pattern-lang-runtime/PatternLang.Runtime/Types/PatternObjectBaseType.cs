using PatternLang.Types.Members;
using PatternLang.Types.Properties;

namespace PatternLang.Types;

public record PatternObjectBaseType<TPatternType, TClrType>(
        string Name,
        PatternNamespace Namespace,
        Type ClrType,
        IPatternType? SuperType = default,
        PatternDomain Domain = default
    )
    : PatternType(Name, Namespace, ClrType, SuperType, Domain), IPatternObject
    where TPatternType : PatternObjectBaseType<TPatternType, TClrType>, IPatternObject
{
    public PatternObjectBaseType() : this(
        nameof(PatternObjectBase<TPatternType, TClrType>),
        new("PatternLang"),
        typeof(PatternObjectBase<TPatternType, TClrType>),
        default,
        default
    )
    { }

    private static object?[]? StripArguments(params object?[]? args)
    {
        List<object> stripped = new();
        object[] namespaces = (args?.OfType<PatternNamespace>() ?? Array.Empty<PatternNamespace>()).Cast<object>().ToArray();
        object[] domains = (args?.OfType<PatternDomain>() ?? Array.Empty<PatternDomain>()).Cast<object>().ToArray();
        stripped.AddRange(namespaces);
        stripped.AddRange(domains);

        return stripped.ToArray();
    }

    public static TDefinitionType GetDefault<TDefinitionType>(params object?[]? args)
        where TDefinitionType : IPatternType
    {
        var a = StripArguments(args);
        return a is not null
            ? (TDefinitionType)Activator.CreateInstance(typeof(TDefinitionType), a)!
            : (TDefinitionType)Activator.CreateInstance(typeof(TDefinitionType))!;
    }

    public static IPatternObject GetDefault(PatternType type, params object?[]? args)
    {
        var a = StripArguments(args);
        return (IPatternObject)Activator.CreateInstance(type.ClrType, a)!;
    }

    public static object GetDefault(Type type, params object?[]? args)
    {
        var a = StripArguments(args);
        return Activator.CreateInstance(type, a)!;
    }

    public override string ToString()
        => $"{Namespace.FullName}.{Name}::{Domain.FullName}";

    protected List<PatternMember<TPatternType, TClrType>> Members { get; } = new();
    protected List<PatternProperty<TPatternType, TClrType>> Properties { get; } = new();
}