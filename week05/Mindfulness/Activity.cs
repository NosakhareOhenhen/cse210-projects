using System;
using System.Threading;
using System.Collections.Generic;

public class Activity
{
    private string _name;        // Stores the name of the activity
    private string _description; // Stores the description of the activity
    protected int _duration;     // Stores the duration of the activity in seconds (protected for derived access)

    // Constructor to initialize the activity with a name and description
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Displays the common starting message for all activities
    public void DisplayStartingMessage()
    {
        Console.Clear(); // Clear console for clean display
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        // Basic input validation
        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.Write("Invalid input. Please enter a positive number of seconds: ");
            input = Console.ReadLine();
        }
        Console.Clear();
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(5); // Pause for 5 seconds with a spinner
    }

    // Displays the common ending message for all activities
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3); // Pause for 3 seconds with a spinner
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} in {_duration} seconds.");
        ShowSpinner(5); // Pause for 5 seconds with a spinner before returning to menu
    }

    // Shows a simple spinner animation for a given number of seconds
    public void ShowSpinner(int seconds)
    {
        List<string> spinnerChars = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[i]);
            Thread.Sleep(200); // Pause for 200 milliseconds
            Console.Write("\b \b"); // Erase the character
            i = (i + 1) % spinnerChars.Count; // Cycle through spinner characters
        }
    }

    // Shows a countdown timer for a given number of seconds
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000); // Pause for 1 second
            if (i < 10) // For single digit numbers, erase one char
            {
                Console.Write("\b \b");
            }
            else // For double digit numbers, erase two chars
            {
                Console.Write("\b \b\b \b");
            }
        }
    }
}