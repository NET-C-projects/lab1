using System;

namespace Generators
{

    abstract class BaseGen
    {
        protected string? name;
        protected int n;
        protected List<int>? numbers;
        protected WorkingMode mode;

        public BaseGen(string Name, string N)
        {
            this.setName(Name);
            this.setN(N);
        }
        public virtual int Average()
        {
            int res = 0;
            if (this.numbers != null)
            {
                res = numbers.Sum();
                switch (this.mode)
                {
                    case WorkingMode.Count_Generated:
                        if (this.n != 0) // по сути если n = 0 <-> чисел нет <-> среднее нулю равно   
                            res /= this.n; // у нас res априори нулю равен
                        break;
                    case WorkingMode.Less:
                        res /= this.numbers.Count();
                        break;
                    case WorkingMode.Exception:
                        throw new NullReferenceException("Числа не были инициализированны - нулевой указатель");
                    case WorkingMode.NotANumber:
                        // ???  нихуя не понял че там они на ошибку кидают - PrototypeGen.cpp line 50
                        // как по мне там пизда какая-то))) я вроде декомпозировал
                        break;
                }
            }

            // по канонам один ретурн
            return res;
        }
        void SetPrev(int prev)
        {
            if (this.numbers != null)
                this.numbers[numbers.Count() - 1] = prev;
            else
                throw new NullReferenceException("Числа не были инициализированны - нулевой указатель");
        }
        int GetPrev()
        {
            int res = 0;
            if (this.numbers != null)
                res = this.numbers.Last();
            else
                throw new NullReferenceException("Числа не были инициализированны - нулевой указатель");
            return res;
        }
        public void setName(string Name)
        {
            if (Name != null)
                this.name = Name;
            else
                throw new NullReferenceException("Имя не было инициализированно - нулевой указатель");
        }
        public void setN(string N)
        {
            try
            {
                this.n = Convert.ToInt32(N);
            }
            catch (FormatException)
            {
                this.mode = WorkingMode.NotANumber;
                throw new ArgumentException("На вход пришло не число");
            }
            if (this.n <= 0)
            {
                this.mode = WorkingMode.Exception;
                throw new ArgumentOutOfRangeException(("Отрицательное количество чисел"));
            }
            else if (this.numbers != null && this.n > this.numbers.Count())
                this.mode = WorkingMode.Count_Generated;
            else
                this.mode = WorkingMode.Less;
        }

        public string getName()
        {
            return this.name;
        }

        public int getN()
        {
            return this.n;
        }
    }
}