using System;


class SquareSpawner
{
    static void Main(string[] args)
    {
        const string QUIT = "q";
        const string GREETING = "Здравствуйте, вас приветствует математическая программа\nпожалуйста введите число: ";
        
        int factorial = 1;
        int sum = 0;
        int maxEven = 0;

        Console.WriteLine(GREETING);

        string input = Console.ReadLine();

        if (input.Equals(QUIT)) return;

        for (int i = 1; i <= int.Parse(input); i++)
        {
            factorial *= i;
            sum += i;
            if (i%2 == 0) maxEven = i;
        }

        Console.WriteLine($"Факториал равен {factorial}\n");
        Console.WriteLine($"Сумма от 1 до {input} равна {sum}\n");
        Console.WriteLine($"Максимальное четное число меньше {input} равно {maxEven}\n");
    }
}
