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
            Console.WriteLine("1. Check ticket pricing based on age (single / group)");
            Console.WriteLine("2. Repeat text x10 times");
            Console.WriteLine("3. Find the 3th word in the sentence");
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
                    TicketMenu();
                    break;
                case "2":
                    LoopText10Times();
                    break;
                /*case "3":
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
    

    static void TicketMenu()
    {
        
        bool subMenu = true;

        while (subMenu)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("===== Ticket Pricing Menu =====");
            Console.WriteLine();
            Console.WriteLine("1. Check ticket price for a single customer");
            Console.WriteLine("2. Calculate total price for a group");
            Console.WriteLine();
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine();
            Console.Write("Select an action: ");

            string? action = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(action))
            {
                Console.WriteLine("Invalid input. Please enter a valid action.");
                CountDownToMenu();
                return;
            }

            switch (action)
            {
                case "1":
                    CheckPrice();
                    break;
                case "2":
                    GroupPrice();
                    break;
                case "0":
                    subMenu = false;
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

        int groupSize = ValidGroupSize("Enter the number of people in the group: ");
        Console.WriteLine();

        Console.WriteLine();

        List<string> standardTickets = new();
        List<string> seniorTickets = new();
        List<string> youthTickets = new();
        List<string> freeTickets = new();

        int totalPrice = 0;

        for (int i = 1; i <= groupSize; i++)
        {
            int age = ValidAgeInput($"Enter the age of person {i}: ");
            Console.WriteLine();

            string ticketType;
            int price;

            if (age < 5 || age >= 100)
            {
                Console.WriteLine("The ticket is for Free! ~ WooHoo!");
                ticketType = "~ FREE ~";
                price = 0;
            }
            else if (age < 20)
            {
                Console.WriteLine("The ticket price for youth is: 80 SEK.");
                ticketType = "Youth (< 20)";
                price = 80;
            }
            else if (age >= 65)
            {
                Console.WriteLine("The ticket price for seniors is: 90 SEK.");
                ticketType = "Senior (65+)";
                price = 90; 
            }
            else
            {
                Console.WriteLine("The standard ticket price is: 120 SEK.");
                ticketType = "Standard";
                price = 120;
                
            }

            totalPrice += price;

            Console.WriteLine();
            string sortedLine = $"{(age + " yrs"),-10}{ticketType,-18}{price,5} SEK";

            if (ticketType == "~ FREE ~")
            {
                freeTickets.Add(sortedLine);
            }
            else if (ticketType == "Youth (< 20)")
            {
                youthTickets.Add(sortedLine);
            }
            else if (ticketType == "Senior (65+)")
            {
                seniorTickets.Add(sortedLine);
            }
            else
            {
                standardTickets.Add(sortedLine);
            }
        
        }

        Console.Clear();
        Console.WriteLine("================================================");
        Console.WriteLine("============== CINEMA RECEIPT ==================");
        Console.WriteLine("================================================");
        Console.WriteLine();

        Console.WriteLine("No.   Age      Type                Price");
        Console.WriteLine("-----------------------------------------------");

        // Prints tickets order by: standard tickets first, then seniors, youth, and free tickets last
        int receiptNumber = 1;

        foreach (var line in standardTickets)
        {
            Console.WriteLine($"{receiptNumber,-5}{line}");
            receiptNumber++;
        }

        foreach (var line in seniorTickets)
        {
            Console.WriteLine($"{receiptNumber,-5}{line}");
            receiptNumber++;
        }

        foreach (var line in youthTickets)
        {
            Console.WriteLine($"{receiptNumber,-5}{line}");
            receiptNumber++;
        }

        foreach (var line in freeTickets)
        {
            Console.WriteLine($"{receiptNumber,-5}{line}");
            receiptNumber++;
        }

        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"Total price for these ({groupSize} people):  {totalPrice} SEK");
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
        while (!int.TryParse(Console.ReadLine(), out number) || number < 0 || number > 130)
        {
            Console.WriteLine();
            Console.Write("Invalid input. Please try again and enter a valid age between 0 and 130: ");
        }

        return number;
    }

    static int ValidGroupSize(string message)
    {
        Console.Write(message);

        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number > 150)
        {
            Console.WriteLine();

            if (number > 150)
            {
                Console.WriteLine("~ Large group detected! ~");
                Console.WriteLine("For groups over 150 people, please contact the cinema to book the entire venue. :)");
                Console.WriteLine();
            }

            Console.Write("Please enter a valid group size between 1 and 150: ");
        }
        return number;

    }


    static void LoopText10Times()
    {
        Console.WriteLine();
        Console.WriteLine("===== Repeat Text x10 times =====");
        Console.WriteLine();

        Console.WriteLine("Please enter the text you want to repeat 10 times: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input. Please enter a non-empty text.");
            CountDownToMenu();
            return;
        }

        Console.WriteLine();


        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"{i}. {input}");

            if (i < 10)
            {
                Console.Write(", "); // Prints a 'comma' after each line except the last one
            }
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Press any key to return to Menu...");
        Console.ReadKey();
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