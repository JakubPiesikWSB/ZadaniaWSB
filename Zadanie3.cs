using System;

class Program
{
    static void Main()
    {
        Console.Write("Ile ocen zdobył uczeń: ");
        int n = Convert.ToInt32(Console.ReadLine());
        double suma = 0;

        for (int i=0; i<n; i++)
        {
            Console.Write($"Podaj ocenę nr. {i+1}: ");
            double grade = Convert.ToDouble(Console.ReadLine());
            suma = suma + grade;
        }

        double avg = suma / n;
        Console.WriteLine($"Średnia: {avg:F2}");

        if (avg >= 3.0)
            Console.Write("Uczeń zdał.");
        else
            Console.Write("Uczeń nie zdał.");
    }
}