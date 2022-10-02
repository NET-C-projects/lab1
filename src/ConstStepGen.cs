namespace Generators;

internal class ConstStepGen : BaseGen
{
    private int step;

    public ConstStepGen(string Name, string N, int Step = 1) : base(Name, N)
    {
        step = Step;
    }

    public void setSep(int Step)
    {
        step = Step;
    }

    public int getStep()
    {
        return step;
    }

    public int pushNumber()
    {
        var newNumber = 0;
        if (Numbers != null)
        {
            if (Numbers.Count() == 0)
            {
                var rnd = new Random();
                newNumber = rnd.Next();
            }
            else
            {
                newNumber = Numbers.Last() + step;
            }


            Numbers.Add(newNumber);
        }

        return newNumber;
    }
}