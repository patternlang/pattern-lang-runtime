namespace PatternLang.Types;

public interface IParameterDefinition<TPatternType, TClrType>
    : IPatternObject<ParameterDefinitionType<TPatternType, TClrType>>
    where TPatternType : PatternObjectBaseType<TPatternType, TClrType>, IPatternObject
{
    bool Validate();
}