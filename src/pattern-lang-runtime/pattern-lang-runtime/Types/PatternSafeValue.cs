namespace PatternLang.Types;

public record PatternSafeValue<TValue>
{
    public PatternSafeValue(TValue? value)
    {
        _value = value;
    }

    public PatternSafeValue<TValue> Value =>
        _value is not null && !_value.Equals(PatternSafeValue<TValue>.GetDefaultValue().Value)
            ? this
            : PatternSafeValue<TValue>.GetDefaultValue().Value;

    private readonly TValue? _value;
    private static PatternSafeValue<TValue>? _defaultValue;

    public PatternSafeValue<TValue> Some => Value.Equals(None) ? None : Value;
    public PatternSafeValue<TValue> None => PatternSafeValue<TValue>.GetDefaultValue().Value;

    internal static PatternSafeValue<TValue> GetDefaultValue()
        => PatternSafeValue<TValue>
            ._defaultValue ??=
            new (
                (TValue?)default(TValue)
                );
}
