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
        protected string _name;
        protected List<int> _numbers;
        protected int _n;
        protected WorkingMode _mode;

        public BaseGen(string name, int n, List<int> numbers, WorkingMode mode)
        {
            this.setName(name);
            this._numbers = numbers;
            this._n = n;
            this._mode = mode;
        }

        public void setName(string name)
        {
            this._name = name;
        }

    }
}