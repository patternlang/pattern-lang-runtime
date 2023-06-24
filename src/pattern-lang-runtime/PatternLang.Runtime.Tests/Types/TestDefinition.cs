using PatternLang.Types;

namespace PatternLang.Runtime.Tests.Types;

public record TestDefinition(IPatternType SuperType, PatternNamespace Namespace, PatternDomain Domain,
    string Name
) : PatternObjectBaseType<PatternString.PatternStringType, string>(Name, Namespace, typeof(string), SuperType, Domain)
{
    public TestDefinition(PatternNamespace Namespace, PatternDomain Domain)
        : this(null, Namespace, Domain, nameof(TestDefinition)) { }

    public override string ToString()
        => $"{Namespace.FullName}.{Name}::{Domain.FullName ?? "Global"}";
}
