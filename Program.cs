using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                case "2":
                    GroupPrice();
                    break;
                /*case "3":
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
        Console.WriteLine("Price List:");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("| Standard           : 120 SEK  |");
        Console.WriteLine("| Senior  (65+)      : 90 SEK   |");
        Console.WriteLine("| Youth   (< 20)     : 80 SEK   |");
        Console.WriteLine("| Infants (0-4)      : FREE ~   |");
        Console.WriteLine("| Elderly (100+)     : FREE ~   |");
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        int age = ValidAgeInput("Enter the age of the customer: ");
        Console.WriteLine();
        if (age < 5 || age >= 100)
        {
            Console.WriteLine("The ticket is for Free! ~ WooHoo!");
        }
        else if (age < 20)
        {
            Console.WriteLine("The ticket price for youth is: 80 SEK.");
        }
        else if (age >= 65)
        {
            Console.WriteLine("The ticket price for seniors is: 90 SEK.");
        }
        else
        {
            Console.WriteLine("The standard ticket price is: 120 SEK.");
        }
        Console.WriteLine();

        CountDownToMenu();
    }


    static void GroupPrice()
    {
        Console.WriteLine();
        Console.WriteLine("===== Total Price For Each Group =====");
        Console.WriteLine();

        int groupSize = ValidAgeInput("Enter the number of people in the group: ");
        Console.WriteLine();

        int totalPrice = 0;

        for (int i = 1; i <= groupSize; i++)
        {
            int age = ValidAgeInput($"Enter the age of person {i}: ");
            Console.WriteLine();

            if (age < 5 || age >= 100)
            {
                Console.WriteLine("The ticket is for Free! ~ WooHoo!");
            }
            else if (age < 20)
            {
                Console.WriteLine("The ticket price for youth is: 80 SEK.");
                totalPrice += 80;
            }
            else if (age >= 65)
            {
                Console.WriteLine("The ticket price for seniors is: 90 SEK.");
                totalPrice += 90;
            }
            else
            {
                Console.WriteLine("The standard ticket price is: 120 SEK.");
                totalPrice += 120;
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("===== Group Summary =====");
        Console.WriteLine();
        Console.WriteLine($"Number of people: {groupSize}");
        Console.WriteLine($"Total price for this group: {totalPrice} SEK");
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("Press any key to return to Menu...");
        Console.ReadKey();
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

        for (int i = 4; i > 0; i--)
        {
            Console.Write($"\rReturning to menu in {i}...   ");
            Thread.Sleep(1000);
        }

        Console.WriteLine();

    }

}