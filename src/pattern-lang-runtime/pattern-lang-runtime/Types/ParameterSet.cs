namespace PatternLang.Types;

public record ParameterSet(IEnumerable<ParameterDefinition> Parameters)
    : PatternSet<ParameterDefinition>(Parameters)
{

}