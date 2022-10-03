using NUnit.Framework;
using Generators;

namespace Generators.Tests;

public class Tests
{


    /*
    int x;
    [SetUp]
    public void SetUp()
    {
        x = 0;
    }
    */

    [Test]
    public void IsNumbersNameEqName()
    {
        Assert.AreEqual("name", (new RandomGen("name", "123")).GetName());
    }



}