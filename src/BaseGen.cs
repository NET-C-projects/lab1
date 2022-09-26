using System;



namespace Generators
{
    enum WorkingMode : byte // надо придумать как назвать нормально
    {
        Count_Generated,
        Exception,
        NotANumber,
    };

    internal class BaseGen
    {
        protected string name;
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

        public void setName(string? Name)
        {
            if (Name != null)
                this.name = new string(Name);
            else
                throw new Exception("Null pointer");
        }

        public void TestOutput()
        {
            Console.WriteLine(this.name);
        }

    }
}