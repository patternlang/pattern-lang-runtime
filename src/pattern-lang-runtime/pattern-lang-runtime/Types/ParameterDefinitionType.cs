namespace PatternLang.Types;

using Properties;

public record ParameterDefinitionType : PatternObjectBaseType
{
    public ParameterDefinitionType()
        : base(
            nameof(ParameterDefinition),
            "PatternLang",
            typeof(ParameterDefinition),
            new PatternObjectBaseType(),
            "Default"
        )
    {
        Properties.Add(new PatternProperty<string>("ParameterName", Namespace, Domain));
        Properties.Add(new PatternProperty<Type>("ParameterClrType", Namespace, Domain));
        Properties.Add(new PatternProperty<IPatternType>("ParameterPatternType", Namespace, Domain));
        Properties.Add(new PatternProperty<IPatternObject>("ParameterValue", Namespace, Domain));
        Properties.Add(new PatternProperty<PatternMutability>("ParameterMutability", PatternMutability.Immutable, Namespace, Domain));
    }

}