using PatternLang.Types.Members;

namespace PatternLang.Types.Properties;

public abstract class PatternPropertyBase<TPatternType, TClrType> : PatternMember<TPatternType, TClrType>
    where TPatternType : PatternObjectBaseType<TPatternType, TClrType>, IPatternObject
{
    protected PatternPropertyBase(TPatternType? pType)
        : base(PatternMembers.Property)
        => PatternType = pType ?? (TPatternType)PatternObjectBaseType<TPatternType, TClrType>.GetDefault(
            typeof(PatternObjectBaseType<TPatternType, TClrType>), new object[0]);
}