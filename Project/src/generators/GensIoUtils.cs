namespace Generators;

public static class GensIoUtils
{
    public static void WriteMessage(string message, int indentSize = 0, bool addEndLIne = true)
    {
        for (var i = 0; i < indentSize; i++)
            Console.Write("\t");

        Console.Write(message);

        if (addEndLIne)
            Console.Write("\n");
    }

    public delegate T Convert<out T>(string? rawValue);

    public static T Read<T>(string message, int indentSize, Convert<T> convertCallback)
    {
        while (true)
        {
            WriteMessage(message, indentSize, false);

            try
            {
                return convertCallback(Console.ReadLine());
            }
            catch (Exception)
            {
                WriteMessage("Введенные данные некорректны", indentSize);
            }
        }
    }

    public static string Read(string message, int indentSize)
    {
        while (true)
        {
            WriteMessage(message, indentSize, false);

            var value = Console.ReadLine();
            if (value != null) return value;

            WriteMessage("Введенные данные некорректны", indentSize);
        }
    }

    public static string InputName(int indentSize) => Read("Введите имя: ", indentSize);
    private static int InputN(int indentSize) => Read("Введите n: ", indentSize, Convert.ToInt32);

    private static AverageBehavior InputAverageBehavior(int indentSize)
    {
        WriteMessage("Выберете поведение калькулятора при недостатке сгенерированных чисел", indentSize);
        WriteMessage("1 - бросить ошибку", indentSize + 1);
        WriteMessage("2 - вернуть NaN", indentSize + 1);
        WriteMessage("2 - подсчет среднего имеющихся чисел", indentSize + 1);

        return Read("Ввод: ", indentSize, CheckAndConvertBehaviourInput);
    }
    
    private static AverageBehavior CheckAndConvertBehaviourInput(string? name)
    {
        if (name == null)
            throw new ArgumentNullException("");

        switch (name[0])
        {
            case '1':
                return AverageBehavior.ThrowException;
            case '2':
                return AverageBehavior.ReturnNaN;
            case '3':
                return AverageBehavior.ReturnAverageOfAvailableNumbers;
            default:
                throw new Exception("");
        }
    }

    public static ConstStepGen CreateConstStepGen(int indentSize)
    {
        var name = InputName(indentSize);
        var n = InputN(indentSize);
        var behavior = InputAverageBehavior(indentSize);
        var step = Read("Шаг генератора: ", indentSize, Convert.ToInt32);
        var startPosition = Read("Стартовая позиция генератора: ", indentSize, Convert.ToInt32);

        return new ConstStepGen(name, n, behavior, step, startPosition);
    }

    public static RandomGen CreateRandomGen(int indentSize)
    {
        var name = InputName(indentSize);
        var n = InputN(indentSize);
        var behavior = InputAverageBehavior(indentSize);

        return new RandomGen(name, n, behavior);
    }

    public static CompositionGen CreateCompositionGen(int indentSize)
    {
        var name = InputName(indentSize);
        var n = InputN(indentSize);
        var behavior = InputAverageBehavior(indentSize);

        return new CompositionGen(name, n, behavior);
    }
}