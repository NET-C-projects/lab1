using System;
using Generators;

namespace Program;

public class Menu
{
    private CompositionGen _compositionGen = null;

    const int StartIndentSize = 0;

    public void Init()
    {
        PrintStartMessage(StartIndentSize);
        PrintHowGensWorks(StartIndentSize);
        GensIoUtils.WriteMessage("Давайте создадим ваш композитный генератор, в котором все и будет храниться!",
            StartIndentSize);
        _compositionGen = GensIoUtils.CreateCompositionGen(StartIndentSize);
    }
    
    private enum ControlFlow
    {
        Quit,
        Continue,
    }

    public void StartEventLoop()
    {
        if (_compositionGen == null) throw new InvalidOperationException("Генератор не был инициализирован");


        var controlFlow = ControlFlow.Continue;
        while (controlFlow != ControlFlow.Quit)
        {
            Console.WriteLine("");
            PrintMenuOptions(StartIndentSize);
            Console.WriteLine("");

            var enteredEvent = GensIoUtils.Read("Введите команду: ", StartIndentSize);

            try
            {
                controlFlow = HandleEvent(enteredEvent, StartIndentSize);
            }
            catch (Exception ex)
            {
                GensIoUtils.WriteMessage(ex.Message, StartIndentSize);
            }
        }
    }
    
    private ControlFlow HandleEvent(string enteredEvent, int indentSize)
    {
        switch (enteredEvent)
        {
            case "0":
                HowGeneratorsWorkMenuItem(indentSize);
                break;
            case "1":
                CreateNewGenMenuItem(indentSize);
                break;
            case "2":
                DeleteGenMenuItem(indentSize);
                break;
            case "3":
                PrintGensMenuItem(indentSize);
                break;
            case "4":
                CalculateAverageMenuItem(indentSize);
                break;
            case "5":
                GenerateNextNumberMenuItem(indentSize);
                break;
            case "q":
                return ControlFlow.Quit;
            default:
                GensIoUtils.WriteMessage("Неизвестная команда", indentSize);
                break;
        }

        return ControlFlow.Continue;
    }

    private void GenerateNextNumberMenuItem(int indentSize)
    {
        Console.WriteLine("");
        GensIoUtils.WriteMessage("Выберете генератор:", indentSize);
        GensIoUtils.WriteMessage("1 - композитный", indentSize + 1);
        GensIoUtils.WriteMessage("2 - вложенный", indentSize + 1);
        GensIoUtils.WriteMessage("прочее - назад", indentSize + 1);

        var input = GensIoUtils.Read("Ввод: ", indentSize, Convert.ToByte);

        double generated;
        switch (input)
        {
            case 1:
                generated = _compositionGen.GenerateNextNumber();
                break;
            case 2:
                var genName = GensIoUtils.InputName(indentSize + 1);
                generated = _compositionGen.FindGenByName(genName).GenerateNextNumber();
                break;
            default:
                return;
        }

        GensIoUtils.WriteMessage($"Сгенерированное число = {generated}", indentSize);
    }

    private void CalculateAverageMenuItem(int indentSize)
    {
        GensIoUtils.WriteMessage("Выберете генератор:", indentSize);
        GensIoUtils.WriteMessage("1 - композитный", indentSize + 1);
        GensIoUtils.WriteMessage("2 - вложенный", indentSize + 1);
        GensIoUtils.WriteMessage("прочее - назад", indentSize + 1);

        var input = GensIoUtils.Read("Ввод: ", indentSize, Convert.ToByte);

        double average;
        switch (input)
        {
            case 1:
                average = _compositionGen.GenerateNextNumber();
                break;
            case 2:
                var genName = GensIoUtils.InputName(indentSize + 1);
                average = _compositionGen.FindGenByName(genName).GenerateNextNumber();
                break;
            default:
                return;
        }

        GensIoUtils.WriteMessage($"Среднее = {average}", indentSize);
    }

    private void PrintGensMenuItem(int indentSize)
    {
        GensIoUtils.WriteMessage("Генераторы:", indentSize);
        foreach (var gen in _compositionGen)
            GensIoUtils.WriteMessage(gen.Name, indentSize + 1);
    }

    private void CreateNewGenMenuItem(int indentSize)
    {
        GensIoUtils.WriteMessage("Выберете генератор", indentSize);
        GensIoUtils.WriteMessage("1 - генератор с постояным шагом", indentSize + 1);
        GensIoUtils.WriteMessage("2 - случайный генератор", indentSize + 1);
        GensIoUtils.WriteMessage("прочее - назад", indentSize + 1);

        var input = GensIoUtils.Read("Ввод: ", indentSize, Convert.ToByte);

        switch (input)
        {
            case 1:
                _compositionGen.PushGen(GensIoUtils.CreateConstStepGen(indentSize + 1));
                break;
            case 2:
                _compositionGen.PushGen(GensIoUtils.CreateRandomGen(indentSize + 1));
                break;
        }
    }

    private void DeleteGenMenuItem(int indentSize)
    {
        var genNameToDelete = GensIoUtils.Read("Введите имя генератора для удаления: ", indentSize);
        _compositionGen.DeleteGenByName(genNameToDelete);
    }

    private static void HowGeneratorsWorkMenuItem(int indentSize)
    {
        while (true)
        {
            Console.WriteLine();
            PrintHowProgramWorksOptions(indentSize);
            Console.WriteLine();

            var input = GensIoUtils.Read("Введите команду: ", indentSize);

            switch (input)
            {
                case "0":
                    PrintHowConsStepGenWorks(indentSize);
                    break;
                case "1":
                    PrintHowRandomGenWorks(indentSize);
                    break;
                case "2":
                    PrintHowCompositionGenWorks(indentSize);
                    break;
                case "3":
                    PrintHowGensWorks(indentSize);
                    break;
                case "b":
                    return;
                default:
                    GensIoUtils.WriteMessage("Неизвестная команда", indentSize);
                    break;
            }
        }
    }

    private static void PrintMenuOptions(int indentSize)
    {
        GensIoUtils.WriteMessage("Меню программы", indentSize);
        GensIoUtils.WriteMessage("0 - Как работают генераторы", indentSize + 1);
        GensIoUtils.WriteMessage("1 - Добавление генератора", indentSize + 1);
        GensIoUtils.WriteMessage("2 - Удаление генератора", indentSize + 1);
        GensIoUtils.WriteMessage("3 - Вывод списка генераторов", indentSize + 1);
        GensIoUtils.WriteMessage("4 - Подсчет среднего числа", indentSize + 1);
        GensIoUtils.WriteMessage("5 - Генерирование числа в генераторе", indentSize + 1);
        GensIoUtils.WriteMessage("q - выход", indentSize + 1);
    }

    private static void PrintHowProgramWorksOptions(int indentSize)
    {
        GensIoUtils.WriteMessage("Как работают генераторы", indentSize);
        GensIoUtils.WriteMessage("0 - Как работает генератор с постоянным шагом", indentSize + 1);
        GensIoUtils.WriteMessage("1 - Как работает генератор псевдослучаных чисел", indentSize + 1);
        GensIoUtils.WriteMessage("2 - Как работает композитный генератор", indentSize + 1);
        GensIoUtils.WriteMessage("3 - В целом о работе генераторов", indentSize + 1);
        GensIoUtils.WriteMessage("b - назад", indentSize + 1);
    }

    private static void PrintHowGensWorks(int indentSize)
    {
        GensIoUtils.WriteMessage("У каждого генератора есть:", indentSize);
        GensIoUtils.WriteMessage("имя", indentSize + 1);
        GensIoUtils.WriteMessage("некоторая константа N, от которой зависит подсчет среднего значения " +
                                        "генератора: либо среднее последних N чисел, либо среднее всех " +
                                        "имеющихся чисел", indentSize + 1);
        GensIoUtils.WriteMessage("его режим работы при недостатке сгенерированных чисел: " +
                                        "случай когда чисел меньше N, случай когда их столько же " +
                                        "и когда больше", indentSize + 1);
        GensIoUtils.WriteMessage("возможность добавления нового числа в генератор и " +
                                        "подсчет среднего значения в соответствии с режимом работы " +
                                        "и константой N", indentSize + 1);
    }

    private static void PrintStartMessage(int indentSize)
    {
        GensIoUtils.WriteMessage("Вас приветсвует программа по генерированию случайных чисел!", indentSize);
        GensIoUtils.WriteMessage("Доступны 3 вида генераторов чисел:", indentSize);
        GensIoUtils.WriteMessage("Генератор с постоянным шагом", indentSize + 1);
        GensIoUtils.WriteMessage("Генератор псевдослучайных чисел", indentSize + 1);
        GensIoUtils.WriteMessage("Композитный генератор", indentSize + 1);
        GensIoUtils.WriteMessage("В программе вся работа происходит в композитном " +
                                        "генераторе: в него добавляются другие типы генераторов", indentSize);
    }


    private static void PrintHowConsStepGenWorks(int indentSize) => GensIoUtils.WriteMessage
    (
        "(Const) Генератор с постоянным шагом создает числа от " +
        "начальной позиции, прибавляя некотрое число.",
        indentSize
    );

    private static void PrintHowRandomGenWorks(int indentStep) => GensIoUtils.WriteMessage
    (
        "(Rand) Генератор псевдослучайных чисел создает числа " +
        "с помощью *ВоЛшЕбНоГо* алгоритма.",
        indentStep
    );

    private static void PrintHowCompositionGenWorks(int indentSize)
    {
        GensIoUtils.WriteMessage(
            "(Composite)Композитный генератор - генератор, сосотящий из других " +
            "генераторов. Можно добавлять соответственно другие генераторы",
            indentSize
        );
        GensIoUtils.WriteMessage(
            "(Composite)Подсчет среднего арифметического числа соответственно считает " +
            "средние всех вложенных генераторов и считает их среднее",
            indentSize
        );
    }
}