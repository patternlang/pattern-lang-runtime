namespace PatternLang.Types;

public record struct ParameterValidator<TParameterType, TParameter>(
    Func<TParameter, bool> Validator)
    where TParameterType : IPatternType
    where TParameter : ParameterDefinitionBase<TParameterType>
{
    public bool Validate(TParameter parameter)
        => Validator(parameter);
}