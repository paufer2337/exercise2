using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;



class Program
{
    static void Main()
    {
        bool isRunning = true;


        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("===== Cinema Exercise Overview =====");
            Console.WriteLine();
            Console.WriteLine("1. Check ticket price by age");
            Console.WriteLine("2. Calculate total price for each group");
            Console.WriteLine("3. Repeat text x10 times");
            Console.WriteLine("4. Find the third word in the sentence");
            Console.WriteLine();
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Select an action: ");

            string? action = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(action))
            {
                Console.WriteLine("Invalid input. Please enter a valid action.");
                CountDownToMenu();
                continue;
            }
        }
    }
    
     static void CountDownToMenu()
    {
        Console.WriteLine();

        for (int i = 3; i > 0; i--)
        {
            Console.Write($"\rReturning to menu in {i}...   ");
            Thread.Sleep(1000);
        }

        Console.WriteLine();

    }

}