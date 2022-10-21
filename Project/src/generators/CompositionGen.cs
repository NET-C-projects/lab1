using System;
using System.Linq;

namespace Generators;

public class CompositionGen : BaseGen
{
    private readonly List<BaseGen> _generators = new List<BaseGen>();

    public CompositionGen(string name, int n, AverageBehavior averageBehavior) : base(name, n, averageBehavior) { }

    public List<BaseGen>.Enumerator GetEnumerator() => _generators.GetEnumerator();

    public override double GenerateNextNumber()
    {
        if (!_generators.Any())
            throw new InvalidOperationException("Требуется хотя бы один генератор");

        var sumOfAverages = _generators.Sum(generator => generator.CalculateAverage());
        var res = sumOfAverages / _generators.Count;

        Numbers.Add(res);
        return res;
    }

    public void DeleteGenByName(string name)
    {
        var index = GetGenIndexByName(name);

        if (index < 0)
            throw new InvalidOperationException("Генератор не найден");

        _generators.RemoveAt(index);
    }

    public void PushGen(BaseGen generator)
    {

        if (GetGenIndexByName(generator.Name) >= 0)
            throw new ArgumentException("Генератор с таким именем уже существует");

        _generators.Add(generator);
    }

    private int GetGenIndexByName(string name)
    {
        return _generators.FindIndex(gen => gen.Name == name);
    }
    public BaseGen FindGenByName(string name)
    {
        int index = GetGenIndexByName(name);
        if (IndexValidate(index))
            throw new ArgumentOutOfRangeException("Генератор не найден");
        return _generators[index];
    }

    public void GenerateNumberInGenerator(string name)
    {
        GenerateNumberInGenerator(GetGenIndexByName(name));
    }

    public void GenerateNumberInGenerator(int index)
    {
        if (IndexValidate(index))
            throw new IndexOutOfRangeException("Генератор не найден");
        _generators[index].GenerateNextNumber();

    }
    public double CalculateAverageInGenerator(string name)
    {
        int index = GetGenIndexByName(name);
        if (IndexValidate(index))
            throw new IndexOutOfRangeException("Генератор не найден");
        return _generators[index].CalculateAverage();
    }

    private bool IndexValidate(int index) => (index < 0 || index > _generators.Count || !_generators.Any());
}
