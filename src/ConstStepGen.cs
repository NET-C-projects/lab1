using System;

namespace Generators
{

    class ConstStepGen : BaseGen
    {
        private int step;
        public ConstStepGen(string Name, string N, int Step = 1) : base(Name, N) => this.step = Step;

        public void setSep(int Step) => this.step = Step;
        public int pushNumber()
        {
            int res = 0;


            return res;
        }
    }
}