using System;
using System.Threading;

public class BreathingActivity : Activity
{
    // Constructor calls the base class constructor with specific name and description
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Runs the breathing activity
    public void Run()
    {
        DisplayStartingMessage(); // Call common starting message from base class

        Console.WriteLine();
        Console.WriteLine("Begin breathing cycle:");
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int cycleDuration = 4; // 4 seconds in, 4 seconds out for a total of 8 seconds per full breath cycle

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountdown(cycleDuration); // Countdown for breathing in
            Console.WriteLine();

            if (DateTime.Now >= endTime) break; // Check if duration expired after "Breathe in"

            Console.Write("Breathe out...");
            ShowCountdown(cycleDuration); // Countdown for breathing out
            Console.WriteLine();
        }

        DisplayEndingMessage(); // Call common ending message from base class
    }
}

