using System;

namespace Generators
{

    abstract class BaseGen
    {
        protected string? name;
        protected int n;
        protected List<int> numbers;

        protected WorkingMode mode;

        public BaseGen(string Name, int N, List<int> Numbers, WorkingMode Mode)
        {
            this.setName(Name);
            this.numbers = Numbers;
            this.setN(N);
            this.setWorkingMode(Mode);
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

        public void setNumbers(List<int> Numbers)
        {
            numbers = Numbers.ToList();
        }
        public void setWorkingMode(WorkingMode Mode)
        {
            this.mode = Mode;
        }

    }
}