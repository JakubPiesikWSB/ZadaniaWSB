using System;

class Program
{
    static void Main()
    {
        Console.Write("W jakich stopniach podajesz temperaturę? (C/F): ");
        string conversionChoice = Console.ReadLine();

        Console.Write("Podaj temperaturę: ");
        double temperature = Convert.ToDouble(Console.ReadLine());

        if (conversionChoice == "C")
        {
            double result = temperature*1.8+32;
            Console.WriteLine($"{temperature}°C = {result}°F");
        }
        else if (conversionChoice == "F")
        {
            double result = (temperature - 32)/1.8;
            Console.WriteLine($"{temperature}°F = {result}°C");
        }
        else
        {
            Console.WriteLine("Błędny wybór skali");
        }
    }
}