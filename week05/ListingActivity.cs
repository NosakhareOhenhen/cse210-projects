using System;
using System.Threading;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts; // List of prompts for listing

    // Constructor calls the base class constructor and initializes the list
    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    // Helper to get a random prompt
    private string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    // Helper to get input from the user for listing items
    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item (or just press Enter to finish if duration runs out): ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
            // If the user inputs nothing and time is up, they can exit the loop.
            // If time is not up, they can keep entering blank lines, but the loop will break when endTime is reached.
        }
        return items;
    }

    // Runs the listing activity
    public void Run()
    {
        DisplayStartingMessage(); // Call common starting message from base class

        Console.WriteLine();
        Console.WriteLine("Ponder on the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.Write("You may begin listing in: ");
        ShowCountdown(5); // Countdown before listing starts

        Console.WriteLine();
        Console.WriteLine("Start listing items now:");
        List<string> listedItems = GetListFromUser(); // Get items from user for the duration

        Console.WriteLine($"You listed {listedItems.Count} items.");
        Console.WriteLine();

        DisplayEndingMessage(); // Call common ending message from base class
    }
}