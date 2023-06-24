namespace PatternLang.Types;

public record PatternSafeValue<TValue>
{
    public PatternSafeValue(TValue? value) => _value = value;

    public TValue? Value =>
        _value is not null || (_value?.Equals(PatternSafeValue<TValue>._defaultValue) ?? true)
            ? _value
            : PatternSafeValue<TValue>.GetDefaultValue();

    private readonly TValue? _value;
    private static TValue? _defaultValue;

    public bool Some => _value is not null && !_value.Equals(None);
    public TValue? None => default;

    internal static TValue? GetDefaultValue()
        => PatternSafeValue<TValue>
            ._defaultValue ??= default(TValue);

    public static implicit operator TValue?(PatternSafeValue<TValue> v)
        => v._value;

    public static implicit operator PatternSafeValue<TValue>(TValue? v)
        => new(v);
}
