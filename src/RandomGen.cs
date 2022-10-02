using System;

namespace Generators;

internal class RandomGen : BaseGen
{
    private Random rnd = new Random();

    public RandomGen(string name, string n) : base(name, n) { }

    public int nextNumber
    {
        get
        {
            var newNumber = rnd.Next();
            Numbers.Add(newNumber);

            return newNumber;
        }
    }
}