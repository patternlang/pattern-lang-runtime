

using PatternLang.Types;
using PatternLang.Types.Members;

namespace PatternLang.Types.Properties;

public class PatternProperty<TPropertyValue> : PatternProperty
{
    public PatternProperty(params object?[] args)
    {
        _domains = args.OfType<PatternDomain>()
            .Distinct()
            .ToArray();

        _namespace = args.OfType<PatternNamespace>()
            .Distinct()
            .FirstOrDefault();

        _field = new(
            args.OfType<TPropertyValue>()
                .Distinct()
                .FirstOrDefault()
        );

        var getter =
            args.OfType<Func<PatternSafeValue<TPropertyValue>>>().FirstOrDefault();
        var setter =
            args.OfType<Func<PatternSafeValue<TPropertyValue>, PatternSafeValue<TPropertyValue>>>().FirstOrDefault();

        Getter = (Func<PatternSafeValue<TPropertyValue>>)(() => _field);

        if (getter is not null)
        {
            Getter = getter;
        }

        Setter = (Func<PatternSafeValue<TPropertyValue>, PatternSafeValue<TPropertyValue>>)
            (value => _field = value);

        if (setter is not null)
        {
            Setter = setter;
        }
    }

    private readonly PatternDomain[] _domains;
    private readonly PatternNamespace _namespace;

    private PatternSafeValue<TPropertyValue> _field;

    public override PatternProperty<TPropertyValue> GetDefault(params object?[] args)
        => new(args);


    public Func<PatternSafeValue<TPropertyValue>> Getter
    {
        get;
        set;
    }

    public PatternSafeValue<TPropertyValue> GetValue(PatternDomain domain)
        => _domains.Contains(domain)
            ?((Func<PatternSafeValue<TPropertyValue>>)(() => Getter.Invoke()))()
            :((Func<PatternSafeValue<TPropertyValue>>)(() =>_field.None))();

    public Func<PatternSafeValue<TPropertyValue>, PatternSafeValue<TPropertyValue>> Setter
    {
        get;
        set;
    }

    public PatternSafeValue<TPropertyValue> SetValue(PatternSafeValue<TPropertyValue> value, PatternDomain domain)
        => _domains.Contains(domain)
            ? Setter(value)
            : _field.None;

    public PatternSafeValue<TPropertyValue> SetValue(TPropertyValue value, PatternDomain domain)
        => _domains.Contains(domain)
            ? Setter(new(value))
            : _field.None;
}