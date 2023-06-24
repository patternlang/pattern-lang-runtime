namespace PatternLang.Types;

public record struct ParameterValidator<TPatternType, TClrType, TParameter>(
    Func<TParameter, bool> Validator)
    where TPatternType : PatternObjectBaseType<TPatternType, TClrType>, IPatternObject
    where TParameter : ParameterDefinitionBase<TPatternType, TClrType>
{
    public bool Validate(TParameter parameter)
        => Validator(parameter);
}