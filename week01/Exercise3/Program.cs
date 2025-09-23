using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);
        Console.WriteLine(number);
        Console.WriteLine("Guess a number between 1 and 10:");
        string input = Console.ReadLine();
        while (number != int.Parse(input))
        {
            if (number > int.Parse(input))
            {
                Console.WriteLine("Too low. Guess again:");
                input = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Too high. Guess again:");
                input = Console.ReadLine();
            } 
        }
    Console.WriteLine("Congratulations! You guessed the number!");

    }
}