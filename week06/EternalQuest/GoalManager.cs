using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");

        string level = "Novice Quester";
        if (_score >= 1000) level = "Apprentice Seeker";
        if (_score >= 2500) level = "Journeyman Explorer";
        if (_score >= 5000) level = "Master Voyager";
        if (_score >= 10000) level = "Eternal Champion";

        Console.WriteLine($"Your current quest level: {level}\n");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nThe types of Goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals set yet. Create some!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalTypeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string pointsInput = Console.ReadLine();
        int points;
        while (!int.TryParse(pointsInput, out points) || points < 0)
        {
            Console.Write("Invalid input. Please enter a positive number for points: ");
            pointsInput = Console.ReadLine();
        }

        Goal newGoal = null;

        switch (goalTypeChoice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                string targetInput = Console.ReadLine();
                int target;
                while (!int.TryParse(targetInput, out target) || target <= 0)
                {
                    Console.Write("Invalid input. Please enter a positive number for the target: ");
                    targetInput = Console.ReadLine();
                }

                Console.Write("What is the bonus for accomplishing it that many times? ");
                string bonusInput = Console.ReadLine();
                int bonus;
                while (!int.TryParse(bonusInput, out bonus) || bonus < 0)
                {
                    Console.Write("Invalid input. Please enter a positive number for the bonus: ");
                    bonusInput = Console.ReadLine();
                }
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type. No goal created.");
                return;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine($"Goal '{name}' created successfully!");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nYou have no goals to record events for. Create some first!");
            return;
        }

        Console.WriteLine("\nThe Goals are:");
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        string choiceInput = Console.ReadLine();
        int goalIndex;

        if (int.TryParse(choiceInput, out goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex - 1];

            int earnedPoints = selectedGoal.RecordEvent();
            _score += earnedPoints;

            Console.WriteLine($"You earned {earnedPoints} points!");
            DisplayPlayerInfo();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. No goals loaded.");
            return;
        }

        _goals.Clear();
        _score = 0;

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length > 0)
            {
                if (int.TryParse(lines[0], out int loadedScore))
                {
                    _score = loadedScore;
                }
                else
                {
                    Console.WriteLine("Warning: Could not parse score from file. Score reset to 0.");
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] parts = line.Split(':');

                    if (parts.Length < 2) continue;

                    string goalType = parts[0];
                    string goalData = parts[1];

                    Goal loadedGoal = null;
                    string[] dataParts = goalData.Split(',');

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            if (dataParts.Length == 4)
                            {
                                string name = dataParts[0];
                                string description = dataParts[1];
                                int points = int.Parse(dataParts[2]);
                                bool isComplete = bool.Parse(dataParts[3]);
                                loadedGoal = new SimpleGoal(name, description, points, isComplete);
                            }
                            break;
                        case "EternalGoal":
                            if (dataParts.Length == 3)
                            {
                                string name = dataParts[0];
                                string description = dataParts[1];
                                int points = int.Parse(dataParts[2]);
                                loadedGoal = new EternalGoal(name, description, points);
                            }
                            break;
                        case "ChecklistGoal":
                            if (dataParts.Length == 6)
                            {
                                string name = dataParts[0];
                                string description = dataParts[1];
                                int points = int.Parse(dataParts[2]);
                                int bonus = int.Parse(dataParts[3]);
                                int target = int.Parse(dataParts[4]);
                                int amountCompleted = int.Parse(dataParts[5]);
                                loadedGoal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                            }
                            break;
                    }

                    if (loadedGoal != null)
                    {
                        _goals.Add(loadedGoal);
                    }
                    else
                    {
                        Console.WriteLine($"Warning: Could not load goal of type '{goalType}'. Data: {goalData}");
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
            _goals.Clear();
            _score = 0;
        }
    }

    public void Start()
    {
        int choice = 0;
        while (choice != 6)
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out choice))
            {
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Console.WriteLine("Goodbye! Keep up the great work on your Eternal Quest!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}