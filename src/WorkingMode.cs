using System;

namespace Generators
{
    public enum WorkingMode : byte // надо придумать как назвать нормально
    {
        Count_Generated,
        Exception,
        NotANumber,
        Less
    };
}