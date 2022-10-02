using System;

namespace Generators
{

    class ConstStepGen : BaseGen
    {
        private int step;
        public ConstStepGen(string Name, string N, int Step = 1) : base(Name, N) => this.step = Step;

        public void setSep(int Step) => this.step = Step;
        public int getStep() { return this.step; }
        public int pushNumber()
        {
            int newNumber = 0;
            if (this.numbers != null)
            {
                if (this.numbers.Count() == 0)
                {
                    Random rnd = new Random();
                    newNumber = rnd.Next();
                }
                else
                    newNumber = numbers.Last() + this.step;


                numbers.Add(newNumber);
            }
            return newNumber;
        }
    }
}