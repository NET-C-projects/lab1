using System;

namespace Generators
{

    abstract class BaseGen
    {
        protected string? name;
        protected List<int> numbers;
        protected int n;
        protected WorkingMode mode;

        public BaseGen(string Name, int N, List<int> Numbers, WorkingMode Mode)
        {
            this.setName(Name);
            this.numbers = Numbers;
            this.n = N;
            this.mode = Mode;
        }

        public void setName(string Name)
        {
            if (Name != null)
                this.name = Name;
            else
                throw new Exception("Null pointer");
        }

        public void setN(int N)
        {
            this.n = N;
        }
        public void TestOutput()
        {
            numbers.ForEach(value => Console.Write(value + " "));
        }

    }
}