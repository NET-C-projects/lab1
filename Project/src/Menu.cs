using Generators;

namespace src;

public class Menu
{
    private const int IndentFactor = 2;
    
    private static void WriteMessage(string message, int indentSize)
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

    CompositionGen createCompositionGenerator()
    {
        while (true)
        {
            WriteMessage("Composition generator creation:\n", 0);

            var name = Read("Enter name: ", 2);
            var n = Read("Enter n: ", 2, Convert.ToInt32);
            
            WriteMessage("Select the\"Calculate Average\" behavior when" +
                         "amount of available numbers is at least N\n", 2);
            var rawAverageBehavior = Read(" (1 - exception; 2 - NaN; 3 - average of available numbers): ", 2,
                Convert.ToByte);
            
            BaseGen.AverageBehavior averageBehavior;

            if (rawAverageBehavior == 1)
            {
                averageBehavior = BaseGen.AverageBehavior.ThrowException;
            }
            if (rawAverageBehavior == 2)
            {
                averageBehavior = BaseGen.AverageBehavior.ReturnNaN;
            }
            if (rawAverageBehavior == 3)
            {
                averageBehavior = BaseGen.AverageBehavior.ReturnAverageOfAvailableNumbers;
            }
            else
            {
                Console.WriteLine("  Entered data is invalid");
                continue;
            }

            return new CompositionGen(name, n, averageBehavior);
        }
    }
}