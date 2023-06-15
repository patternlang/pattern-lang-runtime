using PatternLang.Types.Members;

namespace PatternLang.Types.Properties;

public abstract class PatternProperty : PatternMember
{
    protected PatternProperty()
        : base(PatternMembers.Property)
    {

    }
}