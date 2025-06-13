using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return GetPoints();
        }
        Console.WriteLine("This goal has already been completed.");
        return 0;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {base.GetShortName()} ({base.GetDescription()})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{base.GetShortName()},{base.GetDescription()},{base.GetPoints()},{_isComplete}";
    }
}