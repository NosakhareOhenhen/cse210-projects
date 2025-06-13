using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This goal is already fully completed.");
            return 0;
        }

        _amountCompleted++;
        int earnedPoints = GetPoints();

        if (_amountCompleted == _target)
        {
            earnedPoints += _bonus;
            Console.WriteLine($"Congratulations! You completed '{base.GetShortName()}' and earned a bonus of {_bonus} points!");
        }
        else
        {
            Console.WriteLine($"You recorded an event for '{base.GetShortName()}' and earned {GetPoints()} points. You have completed it {_amountCompleted}/{_target} times.");
        }
        return earnedPoints;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {base.GetShortName()} ({base.GetDescription()}) -- Currently completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{base.GetShortName()},{base.GetDescription()},{base.GetPoints()},{_bonus},{_target},{_amountCompleted}";
    }
}