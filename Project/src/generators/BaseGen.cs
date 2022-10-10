using System;

namespace Generators;

public abstract class BaseGen
{
    private readonly int _n;
    protected AverageBehavior _averageBehavior;
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
        double res = 0;

        if (Numbers.Count >= _n)
            res = Numbers.TakeLast(_n).Sum() / _n;
        else
        {
            switch (_averageBehavior)
            {
                case AverageBehavior.ThrowException:
                    throw new InvalidOperationException("Amount of the numbers must be at least N");
                case AverageBehavior.ReturnAverageOfAvailableNumbers:
                    res = Numbers.Sum() / _n;
                    break;
                case AverageBehavior.ReturnNaN:
                    res = double.NaN;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        return res;

    }

    public abstract double GenerateNextNumber();

}