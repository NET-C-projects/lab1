using System;
using Generators;
namespace Program;

public class Program
{
    static CompositionGen Gens = null;

    static void Main(string[] args)
    {
        Menu m = new();
        m.Init();
        m.StartEventLoop();
    }
}