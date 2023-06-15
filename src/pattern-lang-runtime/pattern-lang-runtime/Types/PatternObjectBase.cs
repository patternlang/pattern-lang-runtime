namespace PatternLang.Types;

using PatternLang.Types.Members;
using Properties;

public abstract class PatternObjectBase
    : IPatternObject<PatternObjectBaseType>
{
    private PatternObjectBaseType? _patternType = null;

    internal protected PatternObjectBase()
    {
    }

    public PatternObjectBaseType PatternType
    {
        get => _patternType ?? throw new ArgumentNullException(nameof(PatternType));
        set => _patternType = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void SetPatternType<TValue>(PatternNamespace @namespace, PatternDomain domain)
        where TValue : PatternObjectBase, IPatternType
        => PatternType =
            PatternObjectBaseType
                .GetDefault<TValue>(null, @namespace, domain, null)
                .PatternType;

    public abstract PatternObjectBase GetDefault(params object?[] args);

}