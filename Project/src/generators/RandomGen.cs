using System;

namespace Generators;

public class RandomGen : BaseGen
{
    private readonly Random _random = new Random();

    public RandomGen(string name, int n, AverageBehavior averageBehavior) : base(name, n, averageBehavior) { }

    public override double GenerateNextNumber()
    {
        var newNumber = _random.Next();
        Numbers.Add(newNumber);

        return newNumber;
    }
}