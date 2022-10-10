using System;
using System.Linq;

namespace Generators;

public class CompositionGen : BaseGen
{
    private readonly List<BaseGen> _generators = new List<BaseGen>();

    public CompositionGen(string name, int n, AverageBehavior averageBehavior) : base(name, n, averageBehavior) { }

    public override double GenerateNextNumber()
    {
        if (!_generators.Any())
            throw new InvalidOperationException("Requires at least one generator");

        var sumOfAverages = _generators.Sum(generator => generator.CalculateAverage());
        var res = sumOfAverages / _generators.Count;

        Numbers.Add(res);
        return res;
    }

    public void DeleteGenByName(string name)
    {
        var index = _generators.FindIndex(generator => generator.Name == name);

        if (index < 0)
            throw new InvalidOperationException("Generator not found");

        _generators.RemoveAt(index);
    }

    public void PushGen(BaseGen generator)
    {
        var genWithSameNameExist = _generators.FindIndex(gen => gen.Name == generator.Name) >= 0;

        if (genWithSameNameExist)
            throw new ArgumentException("Generator with the same name already exists");

        _generators.Add(generator);
    }

    private bool CheckGenByName(string name)
    {

    }
}