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


        while (isRunning) // Main loop: Keeps the main menu active until the user exits)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("===== Loop Control Exercises =====");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.WriteLine("1. Ticket pricing based on age (single / group)");
            Console.WriteLine("2. Repeat text x10 times");
            Console.WriteLine("3. Find the 3rd word in the sentence");
            Console.WriteLine();
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Select an action: ");

            string? action = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(action)) // Prevents empty menu choices = input is not null, empty, or whitespace. If it is -> displays error message and returns to menu.
            {
                Console.WriteLine("Invalid input. Please enter a valid action.");
                CountDownToMenu();
                continue;
            }

            switch (action) // Routes the user to the selected main menu option
            {
                case "1":
                    TicketMenu();
                    break;
                case "2":
                    LoopText10Times();
                    break;
                case "3":
                    GetThirdWord();
                    break;
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
    

    static void TicketMenu() // Keeps ticket-related choices grouped in a submenu
    {
        
        // Allows user to stay in ticket menu until going back
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

            string? action = Console.ReadLine(); // Get user input for ticket menu

            if (string.IsNullOrWhiteSpace(action)) // Prevents empty submenu choices = input is not null, empty, or whitespace. If it is -> displays error message and returns to submenu.
            {
                Console.WriteLine("Invalid input. Please enter a valid action.");
                CountDownToMenu();
                return;
            }

            switch (action) // Handles ticket menu selection
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


    static void CheckPrice() // Determines the ticket price for one customer based on their age and displays the corresponding price or message.
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




    static void GroupPrice() //  Combines group calculation with receipt output to make the result easier to review
   
    {
        Console.WriteLine();
        Console.WriteLine("===== Total Price For Each Group =====");
        Console.WriteLine();
        
        int groupSize = ValidGroupSize("Enter the number of people in the group: "); // Get and validate the group size (1–150) using ValidGroupSize method (scroll down to find corresponding method). 

        
        Console.WriteLine();

        Console.WriteLine();

        // Separate lists for each ticket type to organize/sort the receipt output. Controls the receipt order without changing the input order
        List<string> standardTickets = new();
        List<string> seniorTickets = new();
        List<string> youthTickets = new();
        List<string> freeTickets = new();

        int totalPrice = 0;

        for (int i = 1; i <= groupSize; i++) // Loop through each person and determine ticket type and price. Track total price and group tickets by type for the receipt output at the end.
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

            totalPrice += price; // Adds the price of the current ticket to the total price for the group, which will be displayed at the end of the receipt.

            Console.WriteLine();
            string sortedLine = $"{(age + " yrs"),-10}{ticketType,-18}{price,5} SEK"; // Aligns receipt columns to make the summary easier to read
            
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
        Console.WriteLine("============== GROUP SUMMARY ===================");
        Console.WriteLine("================================================");
        Console.WriteLine();

        Console.WriteLine("No.   Age      Type                Price");
        Console.WriteLine("-----------------------------------------------");

        // Prints tickets order by: standard tickets first, then seniors, youth, and free tickets last
        int receiptNumber = 1;

        foreach (var line in standardTickets) // Prints the standard tickets first, as they are added to the standardTickets list when the ticket type is "Standard"
        {
            Console.WriteLine($"{receiptNumber,-5}{line}");
            receiptNumber++;
        }

        foreach (var line in seniorTickets) // Prints the senior tickets after the standard tickets, as they are added to the seniorTickets list when the ticket type is "Senior (65+)"
        {
            Console.WriteLine($"{receiptNumber,-5}{line}");
            receiptNumber++;
        }

        foreach (var line in youthTickets) // Prints the youth tickets after the senior tickets, as they are added to the youthTickets list when the ticket type is "Youth (< 20)"
        {
            Console.WriteLine($"{receiptNumber,-5}{line}");
            receiptNumber++;
        }

        foreach (var line in freeTickets) // Prints the free tickets last, as they are added to the freeTickets list when the ticket type is "~ FREE ~"
        {
            Console.WriteLine($"{receiptNumber,-5}{line}"); 
            receiptNumber++; 
        }

        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"Total price for these ({groupSize} people):  {totalPrice} SEK"); // Prints the total price for the group at the end of the receipt
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("Press any key to return to Menu...");
        Console.ReadKey();
    }



    static int ValidAgeInput(string message) // Validates the age input and ensures it's a number between 0 and 130. Keeps prompting user until valid input is provided
    {
        Console.Write(message);

        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number < 0 || number > 130) 
        // Checks if the input is a valid integer and within the specified age range
        {
            Console.WriteLine();
            Console.Write("Invalid input. Please try again and enter a valid age between 0 and 130: ");
        }

        return number; // Returns the valid age input as an integer
    }



    static int ValidGroupSize(string message) // Validates group size input + ensures it's a number between 1 and 150. Keeps prompting user until valid input is provided. If the input exceeds 150 -> displays a message about large groups.
    {
        Console.Write(message);

        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number > 150) 
        // Checks if the input is a valid integer and within the specified group size range
        {
            Console.WriteLine();

            if (number > 150) // If the input is greater than 150, it displays a message about large groups
            {
                Console.WriteLine("~ Large group detected! ~");
                Console.WriteLine("For groups over 150 people, please contact the cinema to book the entire venue. :)");
                Console.WriteLine();
            }

            Console.Write("Please enter a valid group size between 1 and 150: ");
        }
        return number; // Returns the valid group size input as an integer

    }



    static void LoopText10Times() // This method prompts the user to enter a text and then repeats that text 10 times, separated by commas. 
    {
        Console.WriteLine();
        Console.WriteLine("===== Repeat Text x10 times =====");
        Console.WriteLine();

        Console.WriteLine("Please enter the text you want to repeat 10 times: ");
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------");
        string? input = Console.ReadLine();
        Console.WriteLine("--------------------------------------------------");

        if (string.IsNullOrWhiteSpace(input)) // Validates that the input is not null, empty, or whitespace. If it is, it displays an error message and returns to the menu.
        {
            Console.WriteLine("Invalid input. Please enter a non-empty text.");
            CountDownToMenu();
            return;
        }

        Console.WriteLine();


        for (int i = 1; i <= 10; i++) // Loops from 1 to 10, printing the input text along with the current iteration number. It also adds a comma after each line except the last one.
        {
            Console.Write($"{i}. {input}"); // Prints the current iteration number and the input text

            if (i < 10)
            {
                Console.Write(", "); // Prints a 'comma' after each line except the last one
            }
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Press any key to return to Menu...");
        Console.ReadKey();
    }



    static void GetThirdWord() // Prompts user to enter a sentence and then extracts + displays the 3rd word from that sentence.
    {
        Console.WriteLine();
        Console.WriteLine("===== Find the 3rd word in the sentence =====");
        Console.WriteLine();

        Console.WriteLine("Please enter a sentence with at least 3 words: ");
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------");
        string? input = Console.ReadLine();
        Console.WriteLine("--------------------------------------------------");

        if (string.IsNullOrWhiteSpace(input)) // Validates that the input is not null, empty, or whitespace. If it is -> displays an error message and returns to menu.
        {
            Console.WriteLine("Invalid input. Please enter a non-empty sentence.");
            CountDownToMenu();
            return;
        }

        string[] words = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); // Splits the input sentence into an array of words using space and tab as delimiters, and removes any empty entries from the resulting array.

        if (words.Length < 3) // Checks if the number of words in the array is less than 3. If it is, it displays an error message and returns to the menu.
        {
            Console.WriteLine("The sentence must contain at least 3 words. Please try again.");
            CountDownToMenu();
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"The 3rd word in the sentence is: '{words[2]}'"); // Prints the 3rd word in the sentence
        Console.WriteLine();

        Console.WriteLine("Press any key to return to Menu...");
        Console.ReadKey();
    }


    static void CountDownToMenu() // This method is used to create a countdown effect before returning to the main menu. 
    {
        Console.WriteLine();

        for (int i = 4; i > 0; i--) // Loops from 4 down to 1, creating a countdown effect. It displays a message with the remaining seconds and then waits for 1 second before updating the message.
        {
            Console.Write($"\rReturning to menu in {i}...   "); // Displays the countdown message with the remaining seconds. The '\r' char is used to return the cursor to the beginning of the line.
            Thread.Sleep(1000); // Pauses the execution of the program before continuing to the next iteration of the loop, creating a delay between each update of the countdown message.
        }

        Console.WriteLine(); // After the countdown is complete, it prints a new line to move the cursor to the next line before returning to the menu.

    }

}