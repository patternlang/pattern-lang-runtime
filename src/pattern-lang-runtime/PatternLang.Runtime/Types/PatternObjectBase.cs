using static PatternLang.Types.PatternInteger;
using static PatternLang.Types.PatternString;

namespace PatternLang.Types;

public abstract class PatternObjectBase<TPatternType, TClrType>
    : IPatternObject<TPatternType>
    where TPatternType : PatternObjectBaseType<TPatternType, TClrType>, IPatternObject
{
    private TPatternType? _patternType = null;

    internal protected PatternObjectBase()
        => SetPatternType(PatternNamespace.DEFAULT, PatternDomain.DEFAULT);

    internal protected PatternObjectBase(PatternNamespace @namespace, PatternDomain domain)
        => SetPatternType(@namespace, domain);

    public TPatternType PatternType
    {
        get => _patternType ?? throw new ArgumentNullException(nameof(PatternType));
        set => _patternType = value ?? throw new ArgumentNullException(nameof(value));
    }

    protected void SetPatternType(PatternNamespace @namespace, PatternDomain domain)
        => PatternType =
            PatternObjectBaseType<TPatternType, TClrType>
                .GetDefault<TPatternType>(null, @namespace, domain, null);

    public abstract PatternObjectBase<TPatternType, TClrType> GetDefault(params object?[] args);

    protected PatternSafeValue<TClrType> _value = new(default);

    public PatternSafeValue<TClrType> Value => _value;

    protected abstract PatternObjectBase<TPatternType, TClrType> ProtectedDefault
    {
        get;
    }
}

public sealed class PatternString : PatternObjectBase<PatternString.PatternStringType, string>
{
    private PatternString? _protectedDefault = null;
    protected override PatternObjectBase<PatternStringType, string> ProtectedDefault
        => _protectedDefault ??= new PatternString(
            null,
            PatternNamespace.DEFAULT,
            PatternDomain.DEFAULT);

    public PatternString(
        string? value,
        PatternNamespace @namespace,
        PatternDomain domain = default) : base()
    {
        SetPatternType(@namespace, domain);
        _value = new(value);
    }

    public override PatternObjectBase<PatternStringType, string> GetDefault(params object?[] args)
        => args.Length < 2
        ? ProtectedDefault
        : new PatternString(
            null,
            args.OfType<PatternNamespace>().FirstOrDefault(),
            args.OfType<PatternDomain>().FirstOrDefault());

    public record PatternStringType(PatternNamespace Namespace,
        PatternDomain Domain) :
        PatternObjectBaseType<PatternStringType, string>(
            nameof(PatternString), Namespace, typeof(string), Domain: Domain)
    {
        public PatternStringType():this(PatternNamespace.DEFAULT, PatternDomain.DEFAULT) { }
    }
}

public sealed class PatternInteger : PatternObjectBase<PatternInteger.PatternIntegerType, long?>
{
    private PatternInteger? _protectedDefault = null;
    protected override PatternObjectBase<PatternIntegerType, long?> ProtectedDefault
        => _protectedDefault ??= new PatternInteger(
            null,
            PatternNamespace.DEFAULT,
            PatternDomain.DEFAULT);

    public PatternInteger(
        long? value,
        PatternNamespace @namespace,
        PatternDomain domain = default) : base()
    {
        SetPatternType(@namespace, domain);
        _value = new(value);
    }

    public override PatternObjectBase<PatternIntegerType, long?> GetDefault(params object?[] args)
        => args.Length < 2
        ? ProtectedDefault
        : new PatternInteger(
            null,
            args.OfType<PatternNamespace>().FirstOrDefault(),
            args.OfType<PatternDomain>().FirstOrDefault());

    public record PatternIntegerType(
        PatternNamespace Namespace,
        PatternDomain Domain) :
    PatternObjectBaseType<PatternIntegerType, long?>(
        nameof(PatternString), Namespace, typeof(long), Domain: Domain)
    {
        public PatternIntegerType() : this(PatternNamespace.DEFAULT, PatternDomain.DEFAULT) { }
    }
}

public sealed class PatternDecimal : PatternObjectBase<PatternDecimal.PatternDecimalType, decimal?>
{
    private PatternDecimal? _protectedDefault = null;
    protected override PatternObjectBase<PatternDecimalType, decimal?> ProtectedDefault
        => _protectedDefault ??= new PatternDecimal(
            null,
            PatternNamespace.DEFAULT,
            PatternDomain.DEFAULT);

    public PatternDecimal(
        decimal? value,
        PatternNamespace @namespace,
        PatternDomain domain = default) : base()
    {
        SetPatternType(@namespace, domain);
        _value = new(value);
    }

    public override PatternObjectBase<PatternDecimalType, decimal?> GetDefault(params object?[] args)
        => args.Length < 2
        ? ProtectedDefault
        : new PatternDecimal(
            null,
            args.OfType<PatternNamespace>().FirstOrDefault(),
            args.OfType<PatternDomain>().FirstOrDefault());

    public record PatternDecimalType(
        PatternNamespace Namespace,
        PatternDomain Domain) :
    PatternObjectBaseType<PatternDecimalType, decimal?>(
        nameof(PatternString), Namespace, typeof(decimal), Domain: Domain)
    {
        public PatternDecimalType() : this(PatternNamespace.DEFAULT, PatternDomain.DEFAULT) { }
    }
}

public sealed class PatternGeneric<TValue> 
    : PatternObjectBase<PatternGeneric<TValue>.PatternGenericType, TValue?>
{
    private PatternGeneric<TValue>? _protectedDefault = null;
    protected override PatternObjectBase<PatternGenericType, TValue?> ProtectedDefault
        => _protectedDefault ??= new PatternGeneric<TValue>(
            default,
            PatternNamespace.DEFAULT,
            PatternDomain.DEFAULT);

    public PatternGeneric(
        TValue? value,
        PatternNamespace @namespace,
        PatternDomain domain = default) : base()
    {
        SetPatternType(@namespace, domain);
        _value = new(value);
    }

    public override PatternObjectBase<PatternGeneric<TValue>.PatternGenericType, TValue?> GetDefault(
        params object?[] args)
        => args.Length < 2
        ? ProtectedDefault
        : new PatternGeneric<TValue>(
            default,
            args.OfType<PatternNamespace>().FirstOrDefault(),
            args.OfType<PatternDomain>().FirstOrDefault());

    public record PatternGenericType(
        PatternNamespace Namespace,
        PatternDomain Domain) :
    PatternObjectBaseType<PatternGenericType, TValue?>(
        nameof(PatternString), Namespace, typeof(TValue), Domain: Domain)
    {
        public PatternGenericType() : this(PatternNamespace.DEFAULT, PatternDomain.DEFAULT) { }
    }
}
