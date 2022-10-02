using System;

namespace Generators;

internal class CompositionGen : BaseGen
{

    List<RandomGen> RandomGeneratos = new List<RandomGen>();
    List<ConstStepGen> ConstStepGenerators = new List<ConstStepGen>();

    public CompositionGen(string name, string n) : base(name, n) { }

    public override double PushNumber()
    {
        double sum = 0;
        foreach (var item in RandomGeneratos)
            sum += item.Average();
        foreach (var item in ConstStepGenerators)
            sum += item.Average();
        double count = RandomGeneratos.Count() + ConstStepGenerators.Count();

        double res = 0;
        if (count != 0)
            res = sum / count;
        else
            throw new DivideByZeroException("Не было создано ни одного генератора");

        Numbers.Add(res);
        return res;
    }

    public void pushRandGen(string name, string n)
    {
        foreach (var item in RandomGeneratos)
            if (item.Name == name)
                throw new ArgumentException("Генератор с таким именем уже есть:\n удалите его или придумайте новое название");

        RandomGeneratos.Add(new RandomGen(name, n));
    }

    public void pushRandGen(RandomGen Generator)
    {
        foreach (var item in RandomGeneratos)
            if (item.Name == Generator.Name)
                throw new ArgumentException("Генератор с таким именем уже есть:\n удалите его или придумайте новое название");

        RandomGeneratos.Add(Generator);
    }

    public void pushConstGen(string name, string n)
    {
        foreach (var item in RandomGeneratos)
            if (item.Name == name)
                throw new ArgumentException("Генератор с таким именем уже есть:\n удалите его или придумайте новое название");

        ConstStepGenerators.Add(new ConstStepGen(name, n));
    }

    public void pushConstGen(ConstStepGen Generator)
    {
        foreach (var item in RandomGeneratos)
            if (item.Name == Generator.Name)
                throw new ArgumentException("Генератор с таким именем уже есть:\n удалите его или придумайте новое название");

        ConstStepGenerators.Add(Generator);
    }

}