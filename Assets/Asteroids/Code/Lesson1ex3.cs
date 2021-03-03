class Program
{
    static void Main(string[] args)
    {
        int factorial = 1;
        int sum = 0;
        int maxEven = 0;

        Console.WriteLine("Здравствуйте, вас приветствует математическая программа\nпожалуйста введите число N.\n");

        string input = Console.ReadLine();

        if (input == "q")
        {
            return;
        }

        for (int i = 1; i <= Int32.Parse(input); i++)
        {
            factorial *= i;
            sum += i;

            if (i%2 == 0)
            {
                maxEven = i;
            }
        }

        Console.WriteLine($"Факториал равен {factorial}\n");
        Console.WriteLine($"Сумма от 1 до N равна {sum}\n");
        Console.WriteLine($"Максимальное четное число меньше N равно {maxEven}\n");
        Console.ReadLine();
    }
}
