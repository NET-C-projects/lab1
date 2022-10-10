
namespace Generators;

public class UtilsForGenerators
{
    private const int IndentFactor = 2;

    private static void WriteMessage(string message, int indentSize = 5)
    {
        for (var i = 0; i < indentSize * IndentFactor; i++)
            Console.Write(" ");

        Console.Write(message);
    }

    private delegate T Convert<out T>(string? rawValue);

    private static T Read<T>(string message, int indentSize, Convert<T> convertCallback)
    {
        while (true)
        {
            WriteMessage(message, indentSize);

            try
            {
                return convertCallback(Console.ReadLine());
            }
            catch (Exception)
            {
                WriteMessage("Entered data is invalid\n", indentSize);
            }
        }
    }

    private static string Read(string message, int indentSize)
    {
        while (true)
        {
            WriteMessage(message, indentSize);

            var value = Console.ReadLine();
            if (value != null) return value;

            WriteMessage("Entered data is invalid\n", indentSize);
        }
    }

    private static string InputName() => Read("Enter name: ", 2);
    private static int InputN() => Read("Enter n: ", 2, Convert.ToInt32);
    private static AverageBehavior InputAverageBehavior()
    {
        WriteMessage("Select the\"Calculate Average\" behavior when" +
                     "amount of available numbers is at least N\n", 2);
        return Read("(1 - exception; 2 - NaN; 3 - average of available numbers): ", 2, CheckAndConvertBehaviourInput);
    }

    public static ConstStepGen CreateConstStepGen()
    {
        var name = InputName();
        var n = InputN();
        var behavior = InputAverageBehavior();
        var step = Read("Enter Genetatro's step:", 2, Convert.ToInt32);
        var startPosition = Read("Enter start position of generator", 2, Convert.ToInt32);
        return new ConstStepGen(name, n, behavior, step, startPosition);
    }

    public static RandomGen CreateRandomGen()
    {
        var name = InputName();
        var n = InputN();
        var behavior = InputAverageBehavior();
        return new RandomGen(name, n, behavior);
    }

    public static CompositionGen CreateCompositionGen()
    {
        var name = InputName();
        var n = InputN();
        var behavior = InputAverageBehavior();
        return new CompositionGen(name, n, behavior);
    }

    private static AverageBehavior CheckAndConvertBehaviourInput(string? name)
    {
        if (name != null)
        {
            if (name[0] == '1') return AverageBehavior.ThrowException;
            else if (name[0] == '2') return AverageBehavior.ReturnNaN;
            else if (name[0] == '3') return AverageBehavior.ReturnAverageOfAvailableNumbers;
            else throw new Exception("");

        }
        else throw new ArgumentNullException("");
    }
}



