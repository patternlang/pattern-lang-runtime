using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternLang.SourceGenerators.Attributes;

[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class PatternModelAttribute : Attribute
{
    public PatternModelAttribute() : base()
    {

    }
}
