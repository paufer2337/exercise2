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
            Console.WriteLine("====================================");
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

            switch (action)
            {
                case "1":
                    CheckPrice();
                    break;
                /*case "2":
                    GroupPrice();
                    break;
                case "3":
                    RepeatText10Times();
                    break;
                case "4":
                    GetThirdWord();
                    break;*/
                case "0":
                    isRunning = false;
                    Console.WriteLine("Exiting the program... Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid action. Please select a valid option.");
                    CountDownToMenu();
                    break;
            }
        }
    
    }
    

    static void CheckPrice()
    {
        Console.WriteLine();
        Console.WriteLine("===== Ticket Price By Age =====");
        Console.WriteLine();
        
        int age = ValidAgeInput("Enter the age of the customer: ");
    }

    static int ValidAgeInput(string message)
    {
        Console.Write(message);

        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number < 0)
        {
            Console.Write("Invalid input. Please try again and enter a valid age: ");
        }

        return number;
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