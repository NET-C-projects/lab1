namespace Generators;

internal abstract class BaseGen
{
    public readonly string Name;
    protected AverageBehavior Behavior;
    protected List<int> Numbers;

    public BaseGen(string name, string n)
    {
        Name = new string(name);
        Numbers = new List<int>();
        N = DecideBehavior(n);
    }

    public int N { get; }

    public int Prev
    {
        set => Numbers[Numbers.Count() - 1] = value;
        get
        {
            if (!Numbers.Any())
                throw new IndexOutOfRangeException("Числа не были инициализированны - пустой список");

            return Numbers.Last();
        }
    }

    private int DecideBehavior(string n)
    {
        var res = 0;

        try
        {
            res = Convert.ToInt32(n);
        }
        catch (FormatException)
        {
            Behavior = AverageBehavior.ReturnNotANumber;
            return res;
        }

        if (res <= 0) Behavior = AverageBehavior.ThrowException;
        if (res > Numbers.Count) Behavior = AverageBehavior.CountLastNNumbers;
        else Behavior = AverageBehavior.CountGeneratedNumbers;


        return res;
    }

    public double Average()
    {
        double res = 0;

        switch (Behavior)
        {
            case AverageBehavior.CountLastNNumbers:
                res = (double)Numbers.TakeLast(N).Sum() / N;
                break;
            case AverageBehavior.CountGeneratedNumbers:
                res = (double)Numbers.Sum() / Numbers.Count();
                break;
            case AverageBehavior.ReturnNotANumber:
                res = double.NaN;
                break;
            case AverageBehavior.ThrowException:
                throw new NullReferenceException("Числа не были инициализированны - нулевой указатель");
        }

        return res;
    }

    internal enum AverageBehavior : byte
    {
        CountGeneratedNumbers,
        ThrowException,
        ReturnNotANumber,
        CountLastNNumbers
    }
}