using System;

namespace Generators;

internal class RandomGen : BaseGen
{
    private Random rnd = new Random();

    public RandomGen(string name, string n) : base(name, n) { }

    public override double PushNumber()
    {
        var newNumber = rnd.Next();
        Numbers.Add(newNumber);

        return newNumber;
    }
}