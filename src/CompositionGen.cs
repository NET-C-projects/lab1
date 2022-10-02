using System;

namespace Generators;

internal class CompositionGen : BaseGen
{

    List<RandomGen> RandomGeneratos = new List<RandomGen>();
    List<ConstStepGen> ConstStepGenerators = new List<ConstStepGen>();

    public CompositionGen(string name, string n) : base(name, n) { }
}