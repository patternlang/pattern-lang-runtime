namespace PatternLang.Types;

public record PatternSet<TSetValue>(IEnumerable<TSetValue> SetValues)
    where TSetValue : IPatternObject
{

}