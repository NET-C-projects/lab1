using System;

namespace Generators;

internal class ConstStepGen : BaseGen
{
    public double Step { set; get; }

    public ConstStepGen(string name, string n, double step = 1) : base(name, n) => Step = step;

    public override double PushNumber()
    {
        var newNumber = Step;
        if (Numbers.Count() != 0)
            newNumber = Numbers.Last() + Step;
        Numbers.Add(newNumber);

        return newNumber;
    }
}