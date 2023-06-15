namespace PatternLang.Types;

public interface IParameterDefinition
    : IPatternObject<ParameterDefinitionType>
{
    bool Validate();
}