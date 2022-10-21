using System;
using Generators;
namespace Program;

public class Menu
{
    private CompositionGen Gens = null;


    public void Init()
    {
        PrintStartMessage();
        PrintHowGensWorks();
        Console.WriteLine("Давайте создадим ваш композитный генератор, в котором все и будет храниться!");
        Gens = UtilsForGenerators.CreateCompositionGen();
    }

    public void StartEventLoop()
    {
        if (Gens == null) throw new InvalidOperationException("Генератор не был инициализирован");

        char input = 'f';
        while (input != 'q')
        {
            PrintMenuOptions();
            input = UtilsForGenerators.Read("Введите команду:", 1)[0];
            try
            {
                switch (input)
                {
                    case '0':
                        MenuPointHowProgramWorks();
                        break;
                    case '1':
                        AddGenToProgramCompositGen();
                        break;
                    case '2':
                        DelGenFromProgramCompositGen();
                        break;
                    case '3':
                        PrintGensInProgram();
                        break;
                    case '4':
                        MenuPointCalculateAverage();
                        break;
                    case '5':
                        MenuPointGenerateNextNumber();
                        break;
                    case 'q':
                        break;
                    default:
                        Console.WriteLine("\nНеизвестная команда\n\n");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }


    private void MenuPointGenerateNextNumber()
    {
        UtilsForGenerators.WriteMessage("Добавление числа у композитного генератора или у вложенного в него?\n" +
                                        "c - Композитный\n" +
                                        "n - Вложенный в него\n" +
                                        "q - Выход из данного пункта меню\n");
        char input = UtilsForGenerators.Read("\tВвод:8", 1)[0];

        double? genetrated = 0;
        switch (input)
        {
            case 'c':
                string genName = UtilsForGenerators.Read("Введите имя генератора, в котором будет генерироваться число:", 2);
                genetrated = Gens.FindGenByName(genName).GenerateNextNumber();
                break;
            case 'n':
                genetrated = Gens.GenerateNextNumber();
                break;
            default:
                Console.WriteLine("Операция не выполнена, выход");
                genetrated = null;
                break;
        }
        if (genetrated != null)
            Console.WriteLine($"Сгенерированное число = {genetrated}");
    }



    private void MenuPointCalculateAverage()
    {
        UtilsForGenerators.WriteMessage("Подсчет среднего у композитного генератора или у вложенного в него\n?" +
                                        "c - Композитный\n" +
                                        "n - Вложенный в него\n" +
                                        "q - Выход из данного пункта меню\n");
        char input = UtilsForGenerators.Read("Ввод:", 2)[0];
        double average = 0;
        switch (input)
        {
            case 'c':
                average = ProgramGenCalculateAverage(Gens);
                Console.WriteLine($"Среднее = {average}");
                break;
            case 'n':
                average = CalculateAverageNeastedGen();
                Console.WriteLine($"Среднее = {average}");
                break;
            default:
                Console.WriteLine("Операция не выполнена, выход");
                break;
        }
    }

    private double CalculateAverageNeastedGen()
    {
        string genName = UtilsForGenerators.Read("Введите имя генератора, в котором будет подсчитывать среднее:", 2);
        double average = 0;
        average = ProgramGenCalculateAverage(Gens.FindGenByName(genName));
        return average;
    }

    private double ProgramGenCalculateAverage(BaseGen gen)
    {
        double average = 0;
        average = Gens.CalculateAverage();
        if (double.Equals(average, double.NaN))
            throw new InvalidOperationException("Должно быть хотя бы N чисел");
        return average;

    }

    private void PrintGensInProgram()
    {
        Console.WriteLine("Генераторы:");
        foreach (var gen in Gens)
            Console.WriteLine(gen.Name);
    }

    private void AddGenToProgramCompositGen()
    {
        UtilsForGenerators.WriteMessage("Какой генератор будем создавать? \n " +
                                        "c - генератор с постоянным шагом\n" +
                                        "r - генератор псевдослучайных чисел\n");
        char whatGenDecision = UtilsForGenerators.Read("\tВвод:", 2)[0];
        switch (whatGenDecision)
        {
            case 'c':
                Gens.PushGen(UtilsForGenerators.CreateConstStepGen());
                break;
            case 'r':
                Gens.PushGen(UtilsForGenerators.CreateRandomGen());
                break;
            default:
                Console.WriteLine("Операция не выполнена, выход");
                break;
        }
    }

    private void DelGenFromProgramCompositGen()
    {
        string genNameToDelete = UtilsForGenerators.Read("Введите имя генератора для удаления:", 2);
        Gens.DeleteGenByName(genNameToDelete);
    }


    private void MenuPointHowProgramWorks()
    {
        char input = 'o';
        while (input != 'q')
        {
            PrintOptionsHowProgramWorks();
            input = UtilsForGenerators.Read("Введите команду:", 2)[0];
            Console.WriteLine();
            switch (input)
            {
                case '0':
                    PrintHowConsStepGenWorks();
                    break;
                case '1':
                    PrintHowRandGenWorks();
                    break;
                case '2':
                    PrintHowCompositGenWorks();
                    break;
                case '3':
                    PrintHowGensWorks();
                    break;
                case 'q':
                    break;
                default:
                    Console.WriteLine("\nНеизвестная команда");
                    break;
            }
        }
    }


    private void PrintMenuOptions() => Console.WriteLine("\n\nМеню программы:\n" +
                                                        "\t0 - Как работают проргамма и генераторы\n" +
                                                        "\t1 - Добавление генератора\n" +
                                                        "\t2 - Удаление генератора\n" +
                                                        "\t3 - Вывод списка генераторов\n" +
                                                        "\t4 - Подсчет среднего числа\n" +
                                                        "\t5 - Генерирование числа в генераторе\n" +
                                                        "\tq - Выход");


    private void PrintOptionsHowProgramWorks() => Console.WriteLine("\t0 - Как работает генератор с постоянным шагом\n" +
                                                                      "\t1 - Как работает генератор псевдослучаных чисел\n" +
                                                                      "\t2 - Как работает композитный генератор\n" +
                                                                      "\t3 - В целом о программе и работе генераторов\n" +
                                                                      "\tq - Выйти из данного пункта меню");

    private void PrintHowGensWorks()
    {
        Console.WriteLine("У каждого генератора есть:\n" +
                        "\t1 - имя\n" +
                        "\t2 - некоторая константа N, от которой зависит подсчет среднего значения генератора: либо среднее последних N чисел, либо среднее всех имеющихся чисел\n" +
                        "\t3 - его режим работы при недостатке сгенерированных чисел: случай когда чисел меньше N, случай когда их столько же и когда больше\n" +
                        "\t4 - возможность добавления нового числа в генератор и подсчет среднего значения в соответствии с режимом работы и константой N\n");
        PrintHowConsStepGenWorks();
        PrintHowRandGenWorks();
        PrintHowCompositGenWorks();
    }

    private void PrintStartMessage() => Console.WriteLine("Вас приветсвует программа по генерированию случайных чисел!\n" +
                                                    "Доступны 3 вида генераторов чисел:\n" +
                                                    "\t1 - Генератор с постоянным шагом\n" +
                                                    "\t2 - Генератор псевдослучайных чисел\n" +
                                                    "\t3 - Композитный генератор" +
                                                    "В программе вся работа происходит в композитном генераторе: в него добавляются другие типы генераторов\n");


    private void PrintHowConsStepGenWorks() => Console.WriteLine("(Const)Генератор с постоянным шагом создает числа от начальной позиции, прибавляя некотрое число.");

    private void PrintHowRandGenWorks() => Console.WriteLine("(Rand)Генератор псевдослучайных чисел создает числа с помощью *ВоЛшЕбНоГо* алгоритма.");

    private void PrintHowCompositGenWorks() => Console.WriteLine("(Composite)Композитный генератор - генератор, сосотящий из других генераторов. Можно добавлять соответственно другие генераторы\n" +
                                                                        "(Composite)Подсчет среднего арифметического числа соответственно считает средние всех вложенных генераторов и считает их среднее");

}