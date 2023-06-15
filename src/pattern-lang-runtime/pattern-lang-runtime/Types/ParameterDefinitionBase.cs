namespace PatternLang.Types;

public abstract record ParameterDefinitionBase<TParameterType>(
        IEnumerable<
            ParameterValidator<
                TParameterType,
                ParameterDefinitionBase<TParameterType>
            >
        >? Validators)
    : IParameterDefinition
    where TParameterType : IPatternType
{
    public TParameterType ParameterType { get; } =
        PatternObjectBaseType.GetDefault<TParameterType>();

    public bool Validate()
    {
        if (Validators is null ||
            !Validators.Any())
        {
            return true;
        }

        foreach (var validator in Validators)
        {
            var result = validator.Validate(this);

            if (!result)
            {
                return false;
            }
        }

        return true;
    }
}