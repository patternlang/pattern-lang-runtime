using PatternLang.Types.Properties;

namespace PatternLang.Types;

public record ParameterDefinitionType<TPatternType, TClrType> 
    : PatternObjectBaseType<TPatternType, TClrType>
    where TPatternType : PatternObjectBaseType<TPatternType, TClrType>, IPatternObject
{
    public ParameterDefinitionType()
        : base(
            nameof(ParameterDefinition<TPatternType, TClrType>),
            "PatternLang",
            typeof(ParameterDefinition<TPatternType, TClrType>),
            Activator.CreateInstance<ParameterDefinitionType<TPatternType, TClrType>>(),
            "Default"
        )
    {
        PatternProperty<TPatternType, TClrType> pName = (PatternProperty<TPatternType, TClrType>)(object)
            new PatternProperty<PatternString.PatternStringType, string>("ParameterName", Namespace, Domain);

        PatternProperty<TPatternType, TClrType> pClrType = (PatternProperty<TPatternType, TClrType>)(object)
            new PatternProperty<PatternGeneric<Type>.PatternGenericType, Type?>("ParameterClrType", Namespace, Domain);

        PatternProperty<TPatternType, TClrType> pPatternType = (PatternProperty<TPatternType, TClrType>)(object)
            new PatternProperty<PatternGeneric<IPatternType>.PatternGenericType, IPatternType?>("ParameterPatternType", Namespace, Domain);

        PatternProperty<TPatternType, TClrType> pValue = (PatternProperty<TPatternType, TClrType>)(object)
            new PatternProperty<PatternGeneric<IPatternObject>.PatternGenericType, IPatternObject?>("ParameterValue", Namespace, Domain);

        PatternProperty<TPatternType, TClrType> pMutability = (PatternProperty<TPatternType, TClrType>)(object)
            new PatternProperty<PatternGeneric<PatternMutability>.PatternGenericType, PatternMutability>(
                "ParameterMutability", PatternMutability.Immutable, Namespace, Domain);

        Properties.Add(pName);
        Properties.Add(pClrType);
        Properties.Add(pPatternType);
        Properties.Add(pValue);
        Properties.Add(pMutability);
    }

}