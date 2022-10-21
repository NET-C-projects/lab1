using System;

namespace Generators;

public class ConstStepGen : BaseGen
{
    private readonly double _step;
    private readonly double _initialNumber;

    public ConstStepGen(
        string name, int n, AverageBehavior averageBehavior, double step, double initialNumber = 0
        )
        : base(name, n, averageBehavior)
    {
        _step = step;
        _initialNumber = initialNumber;
    }

    public override double GenerateNextNumber()
    {
        var newNumber = !Numbers.Any() ? _initialNumber : Numbers.Last() + _step;
        Numbers.Add(newNumber);

        return newNumber;
    }
}