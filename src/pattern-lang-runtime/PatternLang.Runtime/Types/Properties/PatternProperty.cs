

using PatternLang.Types;
using PatternLang.Types.Members;

namespace PatternLang.Types.Properties;

public class PatternProperty<TPatternType, TClrType> : PatternPropertyBase<TPatternType, TClrType>
    where TPatternType : PatternObjectBaseType<TPatternType, TClrType>, IPatternObject
{
    public PatternProperty(params object?[] args) : base(Activator.CreateInstance<TPatternType>())
    {
        _domains = args.OfType<PatternDomain>()
            .Distinct()
            .Select(d => (string)d)
            .ToArray();

        _namespace = args.OfType<PatternNamespace>()
            .Distinct()
            .FirstOrDefault();

        _field = new(
            args.OfType<TClrType>()
                .Distinct()
                .FirstOrDefault()
        );

        var getter =
            args.OfType<Func<PatternSafeValue<TClrType>>>().FirstOrDefault();
        var setter =
            args.OfType<Func<PatternSafeValue<TClrType>, PatternSafeValue<TClrType>>>().FirstOrDefault();

        Getter = (Func<PatternSafeValue<TClrType>>)(() => _field);

        if (getter is not null)
        {
            Getter = getter;
        }

        Setter = (Func<PatternSafeValue<TClrType>, PatternSafeValue<TClrType>>)
            (value => _field = value);

        if (setter is not null)
        {
            Setter = setter;
        }
    }

    private readonly string[] _domains;
    private readonly PatternNamespace _namespace;

    private PatternSafeValue<TClrType> _field;

    public override PatternProperty<TPatternType, TClrType> GetDefault(params object?[] args)
        => new(args);


    public Func<PatternSafeValue<TClrType>> Getter
    {
        get;
        set;
    }

    public PatternSafeValue<TClrType> GetValue(PatternDomain domain)
        => _domains.Contains((string)domain)
            ? ((Func<PatternSafeValue<TClrType>>)(() => Getter.Invoke()))()
            : ((Func<PatternSafeValue<TClrType>>)(() => _field.None))();

    public Func<PatternSafeValue<TClrType>, PatternSafeValue<TClrType>> Setter
    {
        get;
        set;
    }

    protected override PatternObjectBase<TPatternType, TClrType> ProtectedDefault
    {
        get;
    }

    public TClrType? SetValue(PatternSafeValue<TClrType> value, PatternDomain domain)
        => _domains.Contains((string)domain)
            ? ((Func<TClrType?>)(() => Setter(value)))()
            : ((Func<TClrType?>)(() => _field.None))();

    public TClrType? SetValue(TClrType value, PatternDomain domain)
        => _domains.Contains((string)domain)
            ? ((Func<TClrType?>)(() => Setter(value)))()
            : ((Func<TClrType?>)(() => _field.None))();
}