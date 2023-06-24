namespace PatternLang.Types;

public abstract record ParameterDefinitionBase<TPatternType, TClrType>(
        IEnumerable<
            ParameterValidator<
                TPatternType,
                TClrType,
                ParameterDefinitionBase<TPatternType, TClrType>
            >
        >? Validators)
    : IParameterDefinition<TPatternType, TClrType>
    where TPatternType : PatternObjectBaseType<TPatternType, TClrType>, IPatternObject
{
    public PatternObjectBaseType<TPatternType, TClrType> ParameterType { get; } =
        PatternObjectBaseType<TPatternType, TClrType>.GetDefault<PatternObjectBaseType<TPatternType, TClrType>>();

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