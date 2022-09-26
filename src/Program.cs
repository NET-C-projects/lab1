using System;

namespace Generators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<int> myList = new List<int>(1);
            string name = "Name";
            int N = 5;
            int mode = 1;
            BaseGen Test(name, N, myList, mode);
        }
    }
}