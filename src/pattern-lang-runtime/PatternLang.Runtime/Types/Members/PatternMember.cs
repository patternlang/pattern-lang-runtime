namespace PatternLang.Types.Members;

public abstract class PatternMember<TPatternType, TClrType> 
    : PatternObjectBase<TPatternType, TClrType>
    where TPatternType : PatternObjectBaseType<TPatternType, TClrType>, IPatternObject
{
    private PatternMember() { }

    protected PatternMember(PatternMembers memberType) => MemberType = memberType;
    public PatternMembers MemberType { get; } = PatternMembers.None;

    public override PatternObjectBase<TPatternType, TClrType> GetDefault(params object?[] args)
        => throw new NotImplementedException();
}
