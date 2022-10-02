using System;
using System.Linq;

namespace Generators;

internal class CompositionGen : BaseGen
{
    private List<BaseGen> Generators = new List<BaseGen>();

    public CompositionGen(string name, string n) : base(name, n) { }

    public override double PushNumber()
    {
        double sum = 0;
        foreach (var item in Generators)
            sum += item.Average();
        double count = Generators.Count();

        double res = 0;
        if (count != 0)
            res = sum / count;
        else
            throw new DivideByZeroException("Не было создано ни одного генератора");

        Numbers.Add(res);
        base.PushNumber();

        return res;
    }

    public void deleteGenByName(string name)
    {
        foreach (var item in Generators.Where(item => name == item.Name))
        {
            Generators.Remove(item);
            break;
        }
    }


    public void pushGen(BaseGen generator)
    {
        foreach (var item in Generators)
            if (item.Name == generator.Name)
                throw new ArgumentException("Генератор с таким именем уже есть:\n удалите его или придумайте новое название");

        Generators.Add(generator);
    }

    public void pushConstGen(string name, string n, double step) => pushGen(new ConstStepGen(name, n, step));
    public void pushRandGen(string name, string n) => pushGen(new RandomGen(name, n));

}