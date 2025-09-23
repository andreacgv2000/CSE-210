using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int num = -1;
        Console.WriteLine("Enter numbers to sum and average, enter 0 to finish:");
        while (num != 0)
        {

            string usuario = Console.ReadLine();
            num = int.Parse(usuario);
            if (num != 0)
            {
                numbers.Add(num);
            }

        }
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The maximum is: {max}");
    }
}