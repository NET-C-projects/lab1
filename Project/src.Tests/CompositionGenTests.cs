using System;
using NUnit.Framework;
using Generators;
using NUnit.Framework.Internal;

namespace Generators.Tests;


[TestFixture]
public class CompositionGenTests
{
    private CompositionGen gen;
    private int step;
    private int n;

    private string namePushDeleteTo;
    [SetUp]
    public void SetUp()
    {
        step = 3;
        n = 1;
        namePushDeleteTo = "NAME";
        gen = new("Name", n, AverageBehavior.ThrowException);
    }

    [Test]
    public void GenerateNextNumber_ThwowExeption()
    {
        Assert.Throws<InvalidOperationException>(() => gen.GenerateNextNumber());
        gen.PushGen(new ConstStepGen("NameConst", n, AverageBehavior.ReturnAverageOfAvailableNumbers, step));
    }

    [Test]
    public void CalculateAverage_0_3_Return3()
    {
        gen.PushGen(new ConstStepGen("NameConst2", n, AverageBehavior.ReturnAverageOfAvailableNumbers, step));
        gen.FindGenByName("NameConst2").GenerateNextNumber();
        gen.FindGenByName("NameConst2").GenerateNextNumber();
        gen.GenerateNextNumber();
        Assert.AreEqual(step, gen.CalculateAverage());
    }

    [Test]
    public void DeleteGenByName_Name()
    {
        gen.PushGen(new RandomGen(namePushDeleteTo, 2, AverageBehavior.ReturnAverageOfAvailableNumbers));
        gen.DeleteGenByName(namePushDeleteTo);

        Assert.Throws<System.InvalidOperationException>(() => gen.DeleteGenByName(namePushDeleteTo));
    }

    [Test]
    public void GenerateNumberInGenerator_index_minus1()
    {
        Assert.Throws<IndexOutOfRangeException>(() => gen.FindGenByName(""));
    }

}