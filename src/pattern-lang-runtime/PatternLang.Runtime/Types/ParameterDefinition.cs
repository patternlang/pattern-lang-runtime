namespace PatternLang.Types;

public record ParameterDefinition<TPatternType, TClrType>(
    IEnumerable<ParameterValidator<
        TPatternType,
        TClrType,
        ParameterDefinitionBase<TPatternType, TClrType>>>?
        Validators
) : ParameterDefinitionBase<TPatternType, TClrType>(Validators)
    where TPatternType : PatternObjectBaseType<TPatternType, TClrType>, IPatternObject
{

}