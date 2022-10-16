using System;
using Generators;
namespace Program;

public class Program
{
    static List<ConstStepGen> ProgramConstStepGens = new List<ConstStepGen>();
    static List<RandomGen> ProgramRandomGens = new List<RandomGen>();
    static List<CompositionGen> ProgramCompositionGens = new List<CompositionGen>();

    static void Main(string[] args)
    {

        PrintStartMessage();
        char input = '1';
        while (input != 'q')
        {
            switch (input)
            {
                case '0':
                    PrintHowGensWorks();
                    break;
                case '1':
                    PrintHowConsStepGenWorks();
                    break;
                case '2':
                    PrintHowRandGenWorks();
                    break;
                case '3':
                    PrintHowCompositGenWorks();
                    break;
                case '4':
                    break;
                default:
                    Console.WriteLine("\nНеизвестная команда");
                    break;
            }
            PrintMenuOptions();
            Console.Write("Введите команду:");
            input = Console.ReadKey().KeyChar;
        }
    }

    public static void PrintGensInProgram()
    {
        Console.WriteLine("Генераторы с постоянным шагом:\n");
        PrintGens(ProgramConstStepGens);


    }

    public static void PrintGens(List<BaseGen> gen)
    {
        if (gen.Any())
            foreach (var item in gen)
                Console.WriteLine(item.Name);
        else
            Console.WriteLine("Генераторы отсуствуют\n");
    }

    public static void PrintMenuOptions() => Console.WriteLine("\n\nМеню программы:\n" +
                                                           "\t0 - Как работают генераторы\n" +
                                                           "\t1 - Как работает генератор с постоянным шагом\n" +
                                                           "\t2 - Как работает композитны генератор\n" +
                                                           "\t3 - Как работает генератор псевдослучаных чисел\n" +
                                                           "\t4 - Вывод списка генераторов\n" +
                                                           "\t5 - Добавление генератора для использования\n" +
                                                           "\t6 - Подсчет среднего числа у генератора\n" +
                                                           "\t7 - Добавление генератора в композитный генератор\n" +
                                                           "\t8 - Удаление генератора из композитного генератора(по имени/индексу)\n" +
                                                           "\tq - Выход\n");


    public static void PrintStartMessage() => Console.WriteLine("Вас приветсвует программа по генерированию случайных чисел!\n" +
                                                    "Доступны 3 вида генераторов чисел:\n" +
                                                    "\t1 - Генератор с постоянным шагом\n" +
                                                    "\t2 - Генератор псевдослучайных чисел\n" +
                                                    "\t3 - Композитный генератор\n");

    public static void PrintHowGensWorks()
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


    public static void PrintHowConsStepGenWorks() => Console.WriteLine("(Const)Генератор с постоянным шагом создает числа от начальной позиции, прибавляя некотрое число.");

    public static void PrintHowRandGenWorks() => Console.WriteLine("(Rand)Генератор псевдослучайных чисел создает числа с помощью *ВоЛшЕбНоГо* алгоритма.");

    public static void PrintHowCompositGenWorks() => Console.WriteLine("(Composite)Композитный генератор - генератор, сосотящий из других генераторов. Можно добавлять соответственно другие генераторы\n" +
                                                                        "(Composite)Подсчет среднего арифметического числа соответственно считает средние всех вложенных генераторов и считает их среднее");


}