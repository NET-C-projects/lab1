using System;
using NUnit.Framework;
using Generators;
using NUnit.Framework.Internal;

namespace Generators.Tests;


// потому что базовый класс абстрактный
internal class TestGen : BaseGen
{

    public TestGen(string name, int n, AverageBehavior averageBehavior) : base(name, n, averageBehavior) { }
    public override double GenerateNextNumber()
    {
        Numbers.Add(1);
        return 1;
    }
    public void ChangeAverageBehaviour(AverageBehavior newBehavior) => _averageBehavior = newBehavior;

}



[TestFixture]
public class ConstStepGen_IsGenShould
{
    private TestGen gen;

    [SetUp]
    public void SetUp()
    {
        gen = new("Name", 3, AverageBehavior.ThrowException);
    }
    [Test]
    public void CalculateAverage_ThrowException()
    {
        gen.ChangeAverageBehaviour(AverageBehavior.ThrowException);
        Assert.Throws<InvalidOperationException>(() => gen.CalculateAverage());
    }

    [Test]
    public void CalculateAverage_ReturnNaN()
    {
        gen.ChangeAverageBehaviour(AverageBehavior.ReturnNaN);
        Assert.IsNaN(gen.CalculateAverage());
    }

    [Test]
    public void CalculateAverage_Return1()
    {
        gen.ChangeAverageBehaviour(AverageBehavior.ReturnAverageOfAvailableNumbers);
        gen.GenerateNextNumber();
        gen.GenerateNextNumber();
        gen.GenerateNextNumber();
        Assert.AreEqual(1, gen.CalculateAverage(), 0.001);
    }




}