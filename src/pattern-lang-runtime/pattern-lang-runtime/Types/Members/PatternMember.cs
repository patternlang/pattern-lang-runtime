namespace PatternLang.Types.Members;

public abstract class PatternMember : PatternObjectBase
{
    private PatternMember() { }

    protected PatternMember(PatternMembers memberType)
    {
        MemberType = memberType;
    }
    public PatternMembers MemberType { get; } = PatternMembers.None;

    public override PatternObjectBase GetDefault(params object?[] args)
        => throw new NotImplementedException();
}
