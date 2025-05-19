using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries;
    private List<string> prompts;
    private List<string> recentPrompts;
    private const int MaxRecentPrompts = 3;

    public Journal()
    {
        entries = new List<Entry>();
        recentPrompts = new List<string>();
        InitializePrompts();
    }

    private void InitializePrompts()
    {
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What was the most challenging part of my day?",
            "What am I grateful for today?",
            "What did I learn today?",
            "How did I take care of myself today?"
        };
    }

    public void WriteNewEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();

        entries.Add(new Entry(prompt, response, date));
        Console.WriteLine("Entry added successfully!");
    }

    private string GetRandomPrompt()
    {
        List<string> availablePrompts = new List<string>(prompts);
        
        // Remove recently used prompts from available options
        foreach (string recent in recentPrompts)
        {
            availablePrompts.Remove(recent);
        }

        // If we've used all prompts, reset the recent list
        if (availablePrompts.Count == 0)
        {
            recentPrompts.Clear();
            availablePrompts = new List<string>(prompts);
        }

        Random random = new Random();
        int index = random.Next(availablePrompts.Count);
        string selectedPrompt = availablePrompts[index];

        // Track this prompt as recently used
        recentPrompts.Add(selectedPrompt);
        if (recentPrompts.Count > MaxRecentPrompts)
        {
            recentPrompts.RemoveAt(0);
        }

        return selectedPrompt;
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        Console.WriteLine("\nJournal Entries:");
        Console.WriteLine("----------------");
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveJournal(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine(entry.ToFileString());
                }
            }
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadJournal(string filename)
    {
        try
        {
            List<Entry> loadedEntries = new List<Entry>();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                loadedEntries.Add(Entry.FromFileString(line));
            }

            entries = loadedEntries;
            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}