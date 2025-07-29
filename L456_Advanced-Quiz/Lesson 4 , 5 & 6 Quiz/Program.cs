using System;
using System.Globalization;

internal class Program
{
    static void Main(string[] args)
    {
        // Uncomment any part to test it.
    }


    /*
    Question 1:
    BMI Calculation

    The Body Mass Index (BMI) of a person is calculated based on the following formula: 
    BMI = weight / (height x height)

    Note:
    - weight is in kilograms (e.g. 65.0)
    - height is in metres (e.g. 1.70)

    Write a C# program to:
    - prompt the user to enter his/her weight and height
    - calculate the BMI (body mass index)
    - display the BMI and the health category according to the table below:

    BMI Health category
    Below 18.5    Underweight
    18.5 - 23     Normal weight
    23 - 27.5     Overweight
    Above 27.5    Obese
    */

    void BMI_Calculator()
    {
        Console.Write("Enter your weight in kg: ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Enter your height in meters: ");
        double height = double.Parse(Console.ReadLine());

        double bmi = weight / (height * height);
        Console.WriteLine($"Your BMI is: {bmi:F2}");

        if (bmi < 18.5)
            Console.WriteLine("Category: Underweight");
        else if (bmi <= 23)
            Console.WriteLine("Category: Normal weight");
        else if (bmi <= 27.5)
            Console.WriteLine("Category: Overweight");
        else
            Console.WriteLine("Category: Obese");
    }


    /*
Question 2:
Discount Calculation [using if..else]

The discount rate given by a shopping mall is shown below:
----------------------------------------------
| Amount spent ($)      |  Discount Rate (%) |
| 100 and below         |        0           |
| 100 < amount <= 500   |        5           |
| 500 < amount <= 1000  |       10           |
| Above 1000            |       20           |
----------------------------------------------
Write a C# program to:
- prompt the user to enter the amount spent 
- calculate and display the discount given (in percentage)
- calculate and display the discount amount
*/

    void DiscountCalculator()
    {
        Console.Write("Enter amount spent ($): ");
        double amount = double.Parse(Console.ReadLine());
        double discountRate = 0;

        if (amount <= 100)
            discountRate = 0;
        else if (amount <= 500)
            discountRate = 5;
        else if (amount <= 1000)
            discountRate = 10;
        else
            discountRate = 20;

        double discountAmount = amount * (discountRate / 100);
        Console.WriteLine($"Discount Rate: {discountRate}%");
        Console.WriteLine($"Discount Amount: ${discountAmount:F2}");
    }



    /*
Question 3:
Multiplication Table [using repetition structure]

Write a C# program to display the multiplication table for a given number from 1 to 12.

Example:
Enter a number : 8
1  8
2  16
3  24
...
12 96
*/

    void MultiplicationTable()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        for (int i = 1; i <= 12; i++)
        {
            Console.WriteLine($"{i}  {i * number}");
        }
    }



    /*
    Question 4:
    Admin Menu [using methods, loop & nested if]

    Write a C# program that displays the main menu and allows the user to select options to perform BMI calculation, discount calculation, or display a multiplication table. The program should repeatedly display the menu until the user chooses to exit.

    Example:
    ------------- MENU --------------
    [1] Calculate Body Mass Index
    [2] Calculate Discount
    [3] Display Multiplication Table
    [0] Exit
    ---------------------------------
    */

    void AdminMenu()
    {
        int choice;

        do
        {
            Console.WriteLine("------------- MENU --------------");
            Console.WriteLine("[1] Calculate Body Mass Index");
            Console.WriteLine("[2] Calculate Discount");
            Console.WriteLine("[3] Display Multiplication Table");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("---------------------------------");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
                BMI_Calculator();
            else if (choice == 2)
                DiscountCalculator();
            else if (choice == 3)
                MultiplicationTable();
            else if (choice != 0)
                Console.WriteLine("Invalid option. Please try again.");

            Console.WriteLine();
        } while (choice != 0);

        Console.WriteLine("Program ended.");
    }



    /*
    Question 5:
    Write a program that adds up to 5 unique words to a list. 
    The user can enter ‘x’ to stop adding words. 
    Once either 5 words are added or the user stops the program early, 
    the words are listed and the total number of letters in the words are displayed.

    Example:
    Enter a word (or 'x' to stop): apple
    Enter a word (or 'x' to stop): banana
    Enter a word (or 'x' to stop): orange
    Enter a word (or 'x' to stop): x

    List of words:
    - apple
    - banana
    - orange

    Total number of letters: 16
    */

    void WordListGame()
    {
        List<string> words = new List<string>();
        int maxWords = 5;

        while (words.Count < maxWords)
        {
            Console.Write("Enter a word (or 'x' to stop): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "x")
                break;

            if (!words.Contains(input))
            {
                words.Add(input);
            }
            else
            {
                Console.WriteLine("Duplicate word, try another.");
            }
        }

        Console.WriteLine("\nList of words:");
        int totalLetters = 0;
        foreach (var word in words)
        {
            Console.WriteLine($"- {word}");
            totalLetters += word.Length;
        }

        Console.WriteLine($"\nTotal number of letters: {totalLetters}");
    }



/*
Question 6:
Write a program that simulates a number guessing game. 
It first generates a random number between 1 and 100. 
It then prompts the user to guess the correct number. 
The user can enter -1 to end the game, or the game will end after 5 tries.

Example:
Guess the number (between 1 and 100, or enter -1 to quit): 50
Too high!
Guess the number (between 1 and 100, or enter -1 to quit): 25
Too low!
Guess the number (between 1 and 100, or enter -1 to quit): 30
Congratulations! You guessed the correct number in 4 tries.
*/

void NumberGuessingGame()
{
    Random rnd = new Random();
    int target = rnd.Next(1, 101);
    int maxTries = 5;
    int attempts = 0;

    while (attempts < maxTries)
    {
        Console.Write("Guess the number (between 1 and 100, or enter -1 to quit): ");
        int guess = int.Parse(Console.ReadLine());

        if (guess == -1)
        {
            Console.WriteLine("You quit the game.");
            break;
        }

        attempts++;

        if (guess == target)
        {
            Console.WriteLine($"Congratulations! You guessed the correct number in {attempts} tries.");
            break;
        }
        else if (guess > target)
        {
            Console.WriteLine("Too high!");
        }
        else
        {
            Console.WriteLine("Too low!");
        }

        if (attempts == maxTries)
        {
            Console.WriteLine($"Out of tries! The correct number was: {target}");
        }
    }
}

}