namespace PatternLang.Types;

public record ParameterDefinition(
    IEnumerable<ParameterValidator<ParameterDefinitionType, ParameterDefinitionBase<
            ParameterDefinitionType>>>?
        Validators
) : ParameterDefinitionBase<ParameterDefinitionType>(Validators)
{

}