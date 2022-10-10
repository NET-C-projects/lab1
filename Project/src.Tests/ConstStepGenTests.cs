using System;
using NUnit.Framework;
using Generators;
using NUnit.Framework.Internal;

namespace Generators.Tests;


// потому что базовый класс абстрактный
internal class TestGen : BaseGen
{

    public TestGen(string name, int n, AverageBehavior averageBehavior) : base(name, n, averageBehavior) { }
    public override double GenerateNextNumber() => double.NaN;
}



[TestFixture]
public class ConstStepGen_IsGenShould
{
    [Test]
    public void test1()
    {
        var gen1 = new TestGen("Name", 123, AverageBehavior.ReturnAverageOfAvailableNumbers);
        try
        {
            gen1.CalculateAverage();
            Assert.Fail();
        }
        catch (InvalidOperationException) { }
    }
}