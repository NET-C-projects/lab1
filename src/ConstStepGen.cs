using System;

namespace Generators;

internal class ConstStepGen : BaseGen
{
    public int Step { set; get; }

    public ConstStepGen(string name, string n, int step = 1) : base(name, n) => Step = step;

    public int pushNumber()
    {
        var newNumber = Step;
        if (Numbers.Count() != 0)
            newNumber = Numbers.Last() + Step;
        Numbers.Add(newNumber);

        return newNumber;
    }
}