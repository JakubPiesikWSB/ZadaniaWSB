using System;

class Program
{
    static void Main()
    {
        Console.Write("Podaj pierwszą liczbę: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Podaj drugą liczbę: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Wybierz operację (+, -, *, /): ");
        string operation = Console.ReadLine();

        double result;

        if (operation == "+")
            result = a+b;
        else if (operation == "-")
            result = a-b;
        else if (operation == "*")
            result = a*b;
        else if (operation == "/")
        {
            if (b != 0)
                result = a/b;
            else
            {
                Console.Write("Nie można dzielić przez zero");
                return;
            }
        }
        else
        {
            Console.Write("Błędny znak");
            return;
        }

        Console.Write("Wynik: " + result);
    }
}