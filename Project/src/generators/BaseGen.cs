using System;

namespace Generators;

public abstract class BaseGen
{
    private readonly int _n;
    private readonly AverageBehavior _averageBehavior;
    protected readonly List<double> Numbers;

    public BaseGen(string name, int n, AverageBehavior averageBehavior)
    {
        Name = new string(name);
        Numbers = new List<double>();
        _averageBehavior = averageBehavior;
        _n = n;
    }

    public string Name { get; }

    public double PrevNumber
    {
        set
        {
            if (!Numbers.Any())
                throw new IndexOutOfRangeException("Previous number does not exist");

            Numbers[Numbers.Count() - 1] = value;
        }

        get
        {
            if (!Numbers.Any())
                throw new IndexOutOfRangeException("Previous number does not exist");

            return Numbers.Last();
        }
    }
    
    public double CalculateAverage()
    {
        if (Numbers.Count >= _n)
            return Numbers.TakeLast(_n).Sum() / _n;

        return _averageBehavior switch
        {
            AverageBehavior.ThrowException =>
                throw new InvalidOperationException("Amount of the numbers must be at least N"),
            AverageBehavior.ReturnNaN => double.NaN,
            AverageBehavior.ReturnAverageOfAvailableNumbers => Numbers.Sum() / _n,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public abstract double GenerateNextNumber();

    public enum AverageBehavior : byte
    {
        ReturnAverageOfAvailableNumbers = 0,
        ThrowException,
        ReturnNaN,
    }
}