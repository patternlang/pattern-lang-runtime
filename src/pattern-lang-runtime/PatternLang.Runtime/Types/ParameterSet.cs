namespace PatternLang.Types;

public record ParameterSet<TPatternType, TClrType>(IEnumerable<ParameterDefinition<TPatternType, TClrType>> Parameters)
    : PatternSet<ParameterDefinition<TPatternType, TClrType>>(Parameters)
    where TPatternType : PatternObjectBaseType<TPatternType, TClrType>, IPatternObject
{

}